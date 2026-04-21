using RpgSimulator.Core;
using RpgSimulator.Abilities;
using RpgSimulator.Characters;

namespace RpgSimulator.Factories;

public class Goblin : Character
{
    public Goblin() : base("Goblin", maxHealth: 60, baseDamage: 12, defense: 3)
    {}
    protected override int CalculateDamage()
    {
        return BaseDamage + new Random().Next(0,6);
    }
    protected override string GetAttackMessage(ICharacter target) => $"🗡️ Goblin scratches {target.Name} with a rusty knife!";
    protected override void RegisterAbilities() {}
}

public class OrcWarrior : Character
{
    public OrcWarrior() : base("Orc-warrior", maxHealth: 115, baseDamage: 21, defense: 7)
    {
        Abilities.Add(new RageAbility((Warrior)(object)this));
    }

    protected override int CalculateDamage() => BaseDamage + new Random().Next(0,10);
    protected override string GetAttackMessage(ICharacter target) => $"🪓 Orc-warrior chops {target.Name} with an axe!";
    protected override void RegisterAbilities(){}
}

public class Dragon : Character
{
    private int _breathCooldown = 0;
    public Dragon() : base("Dragon", maxHealth: 200, baseDamage: 30, defense: 12){}

    protected override int CalculateDamage()
    {
        _breathCooldown++;
        if(_breathCooldown >= 3)
        {
            _breathCooldown = 0;
            Console.WriteLine("    🔥 Dragon uses FIRE-BREATHING!");
            return BaseDamage * 2;
        }
        return BaseDamage;
    }

    protected override string GetAttackMessage(ICharacter target) => $"🐉 Dragon attacks {target.Name}!";

    protected override void RegisterAbilities() {} 
}

public static class MonsterFactory
{
    
    public static Character Create(int choice) => choice switch
    {
        1 => new Goblin(),
        2 => new OrcWarrior(),
        3 => new Dragon(),
        _ => throw new ArgumentException("Incorrect choice of monster.")
    };

    public static void ShowAvailableMonsters()
    {
        Console.WriteLine($"\n👹 Choose enemy:");
        Console.WriteLine($"    [1] Goblin      | HP: 60  | Damage: 12-18 | Defense: 3");
        Console.WriteLine($"    [2] Orc-warrior | HP: 115 | Damage: 21-31 | Defense: 7");
        Console.WriteLine($"    [3] Dragon      | HP: 200 | Damage: 30-60 | Defense: 12");
    }
}