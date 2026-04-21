
namespace RpgSimulator.Characters;

public class Archer : Character
{
    private int _dodgeChance;
    public int DodgeChance
    {
        get => _dodgeChance;
        private set => _dodgeChance = Math.Clamp(value, 0, 60);
    }
    private readonly Random _random = new();

    public Archer(string name) : base(name, maxHealth: 100, baseDamage: 20, defense: 6)
    {
        DodgeChance = 30;
    }
    protected override int CalculateDamage()
    {
        bool isHeadshot = _random.Next(100) < 25;
        if (isHeadshot)
        {
            Console.WriteLine("    🎯 Head shot!");
            return BaseDamage * 2;
        }
        return BaseDamage;
    }
    protected override string GetAttackMessage(ICharacter target) => $"🏹 {Name} releases an arrow at {target.Name}!";

    protected override void RegisterAbilities()
    {
        Abilities.Add(new MultiShotAbility(this));
    }
    public bool TryDodge()
    {
        bool dodged = _random.Next(100) < DodgeChance;
        if (dodged)
        {
            Console.WriteLine($"    💨 {Name} dodged the attack");
        }
        return dodged;
    }
    public override void ShowStats()
    {
        base.ShowStats();
        Console.WriteLine($"    💨 Dodge: {DodgeChance}%");
    }
}