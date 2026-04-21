using System.Security.Cryptography.X509Certificates;

namespace RpgSimulator.Battle;

public class BattleEngine
{
    private readonly BattleLogger _logger;
    private const int MaxRounds = 15;

    public BattleEngine(BattleLogger logger)
    {
        _logger = logger;
    }

    public ICharacter StartBattle(Character hero, Character enemy)
    {
        _logger.Subscribe(hero);
        _logger.Subscribe(enemy);
        _logger.LogBattleStart(hero, enemy);

        Console.WriteLine("📊 Initial characteristics");

        hero.ShowStats();
        enemy.ShowStats();
        Console.WriteLine();

        int round = 0;
        ICharacter winner;

        while(hero.IsAlive && enemy.IsAlive && round < MaxRounds)
        {
            round++;

            _logger.LogRoundStart(round);

            hero.ShowStats();
            enemy.ShowStats();
            if (hero.IsAlive)
            {
                ExecuteTurn(hero, enemy, isPlayerTurn: true);
            }
            if(!enemy.IsAlive) break;

            Thread.Sleep(600);
            if (enemy.IsAlive)
            {
                ExecuteTurn(enemy, hero, isPlayerTurn: false);
            }
            Thread.Sleep(600);
        }
    }
    
    private void ExecuteTurn(Character attacker, Character defender, bool isPlayerTurn)
    {
        if(!attacker.IsAlive) return;
        if (isPlayerTurn)
        {
            ExecutePlayerTurn(attacker, defender);
        }
        else
        {
            ExecuteAITurn(attacker, defender);
        }
    }
    
    private void ExecutePlayerTurn(Character hero, Character enemy)
    {
        Console.WriteLine($"\n🎮 Your turn, {hero.Name}");
        Console.WriteLine("  [1] Attack");
        Console.WriteLine("  [2] Use ability");
        Console.WriteLine("  [3] Show stats");

        string? input = Console.ReadLine()?.Trim();
        switch (input)
        {
            case "1":
                PerformAttack(hero, enemy);
                break;

            case "2":
                UseAbility(hero, enemy);
                break;

            case "3":
                hero.ShowStats();
                enemy.ShowStats();
                PerformAttack(hero, enemy);
                break;

            default:
                _logger.LogAction($"  {hero.Name} gets lost in thought and attacks by default.");
                PerformAttack(hero, enemy);
                break;
        }
    }

    private void ExecuteAITurn(Character enemy, Character hero)
    {
        Console.WriteLine($"\n🤖 Enemy's turn: {enemy.Name} ");

        var abilities = enemy.GetAbilities();

        double hpPercent = (double)enemy.Health / enemy.MaxHealth;

        var healAbility = abilities.FirstOrDefault(a =>
            a.Name.Contains("исцелени", StringComparison.OrdinalIgnoreCase) ||
            a.Name.Contains("heal", StringComparison.OrdinalIgnoreCase));

        if (hpPercent < 0.3 && healAbility != null)
        {
            _logger.LogAction($"  🤖 {enemy.Name} decides to use {healAbility.Name}!");
            healAbility.Use(enemy, hero);
            return;
        }
        if (abilities.Count > 0 && new Random().Next(100) < 40)
        {
            var offensiveAbilities = abilities
                .Where(a => a != healAbility)
                .ToList();

            if (offensiveAbilities.Count > 0)
            {
                var chosen = offensiveAbilities[new Random().Next(offensiveAbilities.Count)];
                _logger.LogAction($"  🤖 {enemy.Name} использует {chosen.Name}!");
                chosen.Use(enemy, hero);
                return;
            }
        }
        PerformAttack(enemy, hero);
    }

    private void UseAbility(Character hero, Character enemy)
    {
        var abilities = hero.GetAbilities();

        if (abilities.Count == 0)
        {
            _logger.LogAction($"  {hero.Name}: there is no available abilities!");
            PerformAttack(hero, enemy); 
            return;
        }

        hero.ShowAbilities();
        Console.Write("\nChoose ability (number) or [0] for cancel: ");

        if (!int.TryParse(Console.ReadLine(), out int choice) ||
            choice < 1 || choice > abilities.Count)
        {
            if (choice == 0)
            {
                _logger.LogAction($"    {hero.Name} cancel and attacks with default attack.");
                PerformAttack(hero, enemy);
            }
            else
            {
                _logger.LogAction("     Wrong choice. Default attack.");
                PerformAttack(hero, enemy);
            }
            return;
        }
        var selectedAbility = abilities[choice - 1];
        _logger.LogAction($"\n✨ {hero.Name} uses [{selectedAbility.Name}]!");
        selectedAbility.Use(hero, enemy);
    }
    
    private void PerformAttack(Character attacker, ICharacter defender)
    {
        if (defender is Archer archer && archer.TryDodge())
        {
            return;
        }
        attacker.Attack(defender);
    }
}