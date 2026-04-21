using RpgSimulator.Core;
using RpgSimulator.Characters;
namespace RpgSimulator.Abilities;

public class FireballAbility : IAbility
{
    private readonly Mage _mage;
    private readonly Random _random = new();

    public string Name => "Fire ball";
    public int ManaCost => 28;
    public string Description => "Deals 50-70 magic damage.";
    
    public FireballAbility(Mage mage) => _mage = mage;

    public void Use(ICharacter caster, ICharacter target)
    {
        if(!_mage.TrySpendMana(ManaCost)) return;

        int damage = _random.Next(50,71);
        Console.WriteLine($"    🔥 {caster.Name} launches a fireball at {target.Name}!");
        target.TakeDamage(damage);
    }
}