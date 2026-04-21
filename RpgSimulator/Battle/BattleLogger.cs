using RpgSimulator.Core;
using RpgSimulator.Characters;
namespace RpgSimulator.Battle;

public class BattleLogger
{
    private readonly List<string> _log = new();
    public void Subscribe(Character character)
    {
        character.OnDamaged += HandleDamaged;
        character.OnHealed += HandleHealed;
        character.OnDeath += HandleDeath;
    }
    public void UnSubscribe(Character character)
    {
        character.OnDamaged -= HandleDamaged;
        character.OnHealed -= HandleHealed;
        character.OnDeath -= HandleDeath;
    }

    private void HandleDamaged(ICharacter character, int damage)
    {
        string hpInfo  = $"HP: {character.Health}/{character.MaxHealth}";
        string message = $"    🩸 {character.Name} receives {damage} damage. [{hpInfo}]";

        WriteColored(message, GetHpColor(character));
        _log.Add(message);
    }

    private void HandleHealed(ICharacter character, int amount)
    {
        string message = $"    💚 {character.Name} restored {amount} HP. [HP: {character.Health}/{character.MaxHealth}]";
        WriteColored(message, ConsoleColor.Green);
        _log.Add(message);
    }
    private void HandleDeath(ICharacter character)
    {
        string message = $"    💀 {character.Name} fell in battle!";

        Console.WriteLine();
        WriteColored(message, ConsoleColor.DarkRed);
        Console.WriteLine();
        _log.Add(message);   
    }

    public void LogRoundStart(int round)
    {
        string separator = new string('─', 40);
        string message   = $"\n{separator}\n  ⚔️  Round {round}\n{separator}";
        Console.WriteLine(message);
        _log.Add($"    ROUND {round}     ");
    }

    public void LogBattleStart(ICharacter hero, ICharacter enemy)
    {
        Console.WriteLine("\n" + new string('═', 40));
        WriteColored($"    ⚔️ FIGHT IS BEGINS!", ConsoleColor.Yellow);
        Console.WriteLine($"    🔵 {hero.Name}  vs    🔴   {enemy.Name}");
        Console.WriteLine(new string('═', 40) + "\n");
        _log.Add($"БОЙ: {hero.Name} vs {enemy.Name}");
    }
    public void LogBattleEnd(ICharacter winner, ICharacter loser, int totalRounds)
    {
        Console.WriteLine("\n" + new string('═', 40));
        WriteColored($"    🏆 WINNER: {winner.Name}!", ConsoleColor.Yellow);
        Console.WriteLine($"    battle lasted {totalRounds} round(s).");
        Console.WriteLine(new string('═', 40));
        _log.Add($"WINNER: {winner.Name} in {totalRounds} rounds");
    }

    public void LogAction(string message)
    {
        Console.WriteLine(message);
        _log.Add(message);
    }
    public void PrintFullLog()
    {
        Console.WriteLine("\n📜 Full battle log:");
        Console.WriteLine(new string('─', 40));
        foreach (var entry in _log)
            Console.WriteLine(entry);
    }
    private static ConsoleColor GetHpColor(ICharacter character)
    {
        double hpPercent = (double)character.Health / character.MaxHealth;
        return hpPercent > 0.5 ? ConsoleColor.White
             : hpPercent > 0.2 ? ConsoleColor.Yellow
             : ConsoleColor.Red;
    }

    private static void WriteColored(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}