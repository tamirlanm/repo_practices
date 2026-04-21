
public class RageAbility : IAbility
{
    private readonly Warrior _warrior;
    public string Name => "Rage";
    public int ManaCost => 0;
    public string Description => "Double damage to 3 turns.";

    public RageAbility(Warrior warrior) => _warrior = warrior;

    public void Use(ICharacter caster, ICharacter target)
    {
        _warrior.ActivateRage(3);
    }
}