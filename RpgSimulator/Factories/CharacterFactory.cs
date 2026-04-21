using RpgSimulator.Characters;
using RpgSimulator.Core;
namespace RpgSimulator.Factories;

public static class CharacterFactory
{
    public static readonly IReadOnlyList<string> AvailableTypes = new[] {"warrior", "mage", "archer", "paladin"};

    public static Character Create(string type, string name)
    {
        return type.ToLower().Trim() switch
        {
            "1" or "warrior" => new Warrior(name),
            "2" or "mage" => new Mage(name),
            "3" or "archer" => new Archer(name),
            "4" or "paladin" => new Paladin(name),
            _ => throw new ArgumentException($"Unknown type character: '{type}'. " + $"Available: {string.Join(", ", AvailableTypes)}")
        };
    }

    public static void ShowAvailableClasses()
    {
        Console.WriteLine($"\n⚔️    Available classes:");
        Console.WriteLine($"    [1] warrior - Warrior       | HP: 125 | Damage: 24 | Defense: 10 | 💥 Rage");
        Console.WriteLine($"    [2] mage    - Mage          | HP: 90  | Damage: 18 | Defense: 4 | 🔥 Fireball");
        Console.WriteLine($"    [3] archer  - Archer        | HP: 100 | Damage: 20 | Defense: 6 | 🏹 Multishot");
        Console.WriteLine($"    [4] paladin - Paladin       | HP: 110 | Damage: 22 | Defense: 8 | 💚 Healing");
    }
}