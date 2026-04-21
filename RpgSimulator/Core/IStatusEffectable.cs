namespace RpgSimulator.Core;

public enum StatusEffect
{
    Frozen,
    Poisoned,
    Burning,
    Stunned
}

public interface IStatusEffectable
{
    void ApplyStatus(StatusEffect effect, int duration);
    bool HasStatus(StatusEffect effect);
    void TickStatus();
}