namespace RpgSimulator.Abilities;

public class FrostNovaAbility : IAbility
{
    private readonly Mage _mage;
    private readonly Random _random = new();

    public string Name => "Frost nova";
    public int ManaCost => 38;
    public string Description => "Deals 30-38 damage and freezez goal 1 per turn";

    public FrostNovaAbility(Mage mage) => _mage = mage;

    public void Use(ICharacter caster, ICharacter target)
    {
        if(!_mage.TrySpendMana(ManaCost)) return;

        int damage = _random.Next(30,39);

        Console.WriteLine($"    ❄️ {caster.Name} sends a burst of ice flying around {target.Name}");
        Console.WriteLine($"    🧊 {target.Name} receives {damage} damage and FROZEN for 1 turn");

        target.TakeDamage(damage);

        if(target.IsAlive && target is IStatusEffectable effectTarget)
        {
            effectTarget.ApplyStatus(StatusEffect.Frozen, duration: 1);
        }else if (target.IsAlive)
        {
            Console.WriteLine($"    [System]: {target.Name} receives status Frozen");
        }
    }
}  