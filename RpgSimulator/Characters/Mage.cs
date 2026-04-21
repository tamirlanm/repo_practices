namespace RpgSimulator.Characters;
public class Mage : Character
{
    private int _mana;
    public int Mana => _mana;
    public int MaxMana {get;}

    private readonly Random _random = new();
    public Mage(string name) : base(name, maxHealth: 90, baseDamage: 18, defense: 4)
    {
        MaxMana = 100;
        _mana = MaxMana;
    }

    protected override int CalculateDamage()
    {
        int bonus = _random.Next(0,18);
        return BaseDamage + bonus;
    }
    protected override void RegisterAbilities()
    {
        Abilities.Add(new FireballAbility(this));
        Abilities.Add(new FrostNovaAbility(this));
    }

    public bool TrySpendMana(int amount)
    {
        if(_mana < amount)
        {
            Console.WriteLine($"    {Name}: not enough mana! ({_mana})/{MaxMana} ");
            return false;
        }
        _mana -= amount;
        return true;
    }
    public void RestoreMana(int amount)
    {
        _mana = Math.Min(MaxMana, _mana + amount);
        Console.WriteLine($"    ✨ {Name} restored {amount} mana. ({_mana}/{MaxMana})");
    }
    public override void ShowStats()
    {
        base.ShowStats();
        string manaBar = new string('▓', (int)Math.Round((double)_mana/MaxMana * 10));
        Console.WriteLine($"    💧 Mana: [{manaBar, -10}] {_mana}/{MaxMana}");
    }
}