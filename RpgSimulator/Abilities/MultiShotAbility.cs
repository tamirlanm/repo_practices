
using RpgSimulator.Core;
using RpgSimulator.Characters;
namespace RpgSimulator.Abilities;


public class MultiShotAbility : IAbility
{
    private readonly Archer _archer;
    private readonly Random _random = new();

    public string Name => "Multi shot";
    public int ManaCost => 0;
    public string Description => "Fires 3 arrows in a row, each dealing 60% of base damage";

    public MultiShotAbility(Archer archer) => _archer = archer;

    public void Use(ICharacter caster, ICharacter target)
    {
        if (!target.IsAlive)
        {
            Console.WriteLine($"    {caster.Name}: goal is already dead!");
            return;
        }
        Console.WriteLine($"    🏹 {caster.Name} fires a barrage of arrows at {target.Name}");
        int arrows = 3;
        int totalDamage = 0;

        for(int i = 1; i <= arrows; i++){
            if (!target.IsAlive)
            {
                Console.WriteLine($"    💀 {target.Name} died after {i - 1}th arrow!");
                break;
            }
            int arrowDamage = (int)(_random.Next(18,23) * 0.6);
            
            bool isCrit = _random.Next(100) < 15;
            if (isCrit)
            {
                arrowDamage *= 2;
                Console.WriteLine($"    Arrow {i}: 🎯 CRIT! {arrowDamage} damage");
            }
            else
            {
                Console.WriteLine($"    Arrow {i}: {arrowDamage} damage");
            }

            target.TakeDamage(arrowDamage);
            totalDamage += arrowDamage;
        }
        Console.WriteLine($"    📊 Multi shot: sum damage = {totalDamage}");
    }

    
}