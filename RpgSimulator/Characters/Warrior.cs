using RpgSimulator.Core;
using RpgSimulator.Abilities;
namespace RpgSimulator.Characters;

public class Warrior : Character
{
    private bool _rageActive = false;
    private int _rageTurnsLeft = 0;
    private readonly Random _random = new();

    public Warrior(string name) : base(name, maxHealth: 125, baseDamage: 24, defense: 10)
    {
       // Abilities.Add(new RageAbility(this)); 
    }
    protected override int CalculateDamage()
    {
        int damage = _rageActive ? BaseDamage * 2 : BaseDamage;

        bool isCrit = _random.Next(100) < 20;
        if (isCrit)
        {
            damage = (int)(damage * 1.25);
            Console.WriteLine("    💥 CRITICAL HIT!   ");
        }
        if (_rageActive)
        {
            _rageTurnsLeft--;
            if(_rageTurnsLeft <= 0)
            {
                _rageActive = false;
                Console.WriteLine($"    {Name}: rage died down.");
            }
        }

        return damage;
    }


    public void ActivateRage(int turns = 3)
    {
        _rageActive = true;
        _rageTurnsLeft = turns;
        Console.WriteLine($"    🔥 {Name} goes into a RAGE for {turns} turn(s)!. Damage x2!");
    }

    protected override string GetAttackMessage(ICharacter target) => $"⚔️   {Name} deals a powerful blow to {target.Name}!";

    protected override void RegisterAbilities()
    {
        Abilities.Add(new RageAbility(this));
    }
    public override void ShowStats()
    {
        base.ShowStats();
        if (_rageActive)
        {
            Console.WriteLine($"    🔥 Rage is active ({_rageTurnsLeft}) turn)");
        }
    }
}