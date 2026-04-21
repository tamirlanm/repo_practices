using RpgSimulator.Core;
using RpgSimulator.Characters;
namespace RpgSimulator.Abilities;

public class DivineHealAbility : IAbility
{
    private readonly Paladin _paladin;

    public string Name => "Divide healing";
    public int ManaCost => 0;
    public string Description => "Uses accumulated sacred power for healing.";
    public DivineHealAbility(Paladin paladin) => _paladin = paladin;
    
    public void Use(ICharacter caster, ICharacter target)
    {
        _paladin.SpendHolyPowerForHeal();
    }
}