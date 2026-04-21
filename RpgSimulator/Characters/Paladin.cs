
namespace RpgSimulator.Characters;

public class Paladin : Character
{
    private int _holyPower = 0;
    private const int MaxHolyPower = 5;
    
    public Paladin(string name) : base(name, maxHealth: 110, baseDamage: 22, defense: 8){}
    protected override void CalculateDamage()
    {
        if(_holyPower < MaxHolyPower)
        {
            _holyPower++;
            Console.WriteLine($"    ✨ {Name} accumulates sacred power ({_holyPower}/{MaxHolyPower})");
        }
        return BaseDamage;
    }

    protected override void GetAttackMessage(ICharacter target) => $"🔨 {Name} hist with a hammer at {target.Name}!";

    protected override void RegisterAbilities()
    {
        Abilities.Add(new DivineHealAbility(this));
        Abilities.Add(new HolySmiteAbiltiy(this));
    }

    public void HealFromSmite(int amount)
    {
        Heal(amount);
    }
    public void SpendHolyPowerForHeal()
    {
        if(_holyPower < 3)
        {
            Console.WriteLine($"    {Name}: not enough sacred power! ({_holyPower}/{MaxHolyPower})");
            return;
        }
        int healAmount = _holyPower * 15;
        _holyPower = 0;
        Heal(healAmount);
        Console.WriteLine($"    💚 {Name} uses sacred power and restores {healAmount} HP!");
    }
    public override void ShowStats()
    {
        base.ShowStats();
        Console.WriteLine($"    ✨ Sacred power: {_holyPower}/{MaxHolyPower}");
    }
}