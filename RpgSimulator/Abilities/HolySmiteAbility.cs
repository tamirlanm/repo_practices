
namespace RpgSimulator.Abilities;

public class HolySmiteAbiltiy : IAbility
{
    private readonly Paladin _paladin;
    private readonly Random _random = new();

    public string Name => "Holy hit";
    public int MaxMana => 0;
    public string Description => "Deals 40-55 sacred damage and restores 20% of that damage to the Paladin";

    public HolySmiteAbiltiy(Paladin paladin) => _paladin = paladin;

    public void Use(ICharacter caster, ICharacter target)
    {
        if (!target.IsAlive)
        {
            Console.WriteLine($"    {caster.Name}: goal is already dead!");
        }
        int damage = _random.Next(40,56);

        Console.WriteLine($"    ✨ {caster.Name} summons the sacred light and unleashes it upon {target.Name}");
        Console.WriteLine($"    💥 {target.Name} receives {damage} holy power!");
        target.TakeDamge(target);

        if(target.IsAlive || damage > 0)
        {
            int healBack = (int)(damage * 0.20);
            Console.WriteLine($"    💚 sacred vampirism: {caster.Name} restores {healBack} HP!");

            if(caster is Paladin paladin)
            {
                paladin.HealFromSmite(healBack);
            }
        }


    }
}