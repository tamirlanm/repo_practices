namespace RpgSimulator.Core;

public class Warrior : Character
{
    private bool _rageActive = false;

    public Warrior(string name) : base(name,health: 120, baseDamage: 24)
    {
        Abilities.Add(new RageAbility(this)); 
    }
    protected override int CalculateDamage()
    {
        return _rageActive ? BaseDamage * 2 : BaseDamage;
    }
    public void ActivateRage() => _rageActive = true;
}