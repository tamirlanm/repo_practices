namespace RpgSimulator.Core;

public interface ICharacter
{
    string Name {get;}
    int Health {get;}
    int MaxHealth {get;}
    bool IsAlive {get;}

    void Attack(ICharacter target);
    void TakeDamage(int damage);
    
}