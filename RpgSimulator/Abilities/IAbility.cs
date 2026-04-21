using RpgSimulator.Core;
using RpgSimulator.Characters;
namespace RpgSimulator.Abilities;

public interface IAbility
{
    string Name {get;}
    int ManaCost { get;}
    string Description {get;}
    void Use(ICharacter caster, ICharacter target);
}
