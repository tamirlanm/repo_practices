using RpgSimulator.Battle;
using RpgSimulator.Factories;
using RpgSimulator.Core;

Console.OutputEncoding = System.Text.Encoding.UTF8;

bool playAgain = true;

while (playAgain)
{
    PrintWelcome();
    CharacterFactory.ShowAvailableClasses();
    Console.WriteLine("\nChoose class (warrior/mage/archer/paladin): ");
    string classType = Console.ReadLine()?.Trim() ?? "warrior";

    Console.Write("Write hero name:  ");
    string heroName = Console.ReadLine()?.Trim() ?? "Hero";

    Character hero;
    try
    {
        hero = CharacterFactory.Create(classType, heroName);
        Console.WriteLine($"\n✅ Created {classType}: {heroName}");
        hero.ShowStats();
    }
    catch( ArgumentException ex)
    {
        Console.WriteLine($"❌ Error: {ex.Message}. Creating warrior by default");
        hero = CharacterFactory.Create("warrior", heroName);
    }

    MonsterFactory.ShowAvailableMonsters();
    Console.Write("\nChoose enemy [1-3]: ");

    Character enemy;
    if (int.TryParse(Console.ReadLine(), out int monsterChoice) &&
        monsterChoice is >= 1 and <= 3)
    {
        enemy = MonsterFactory.Create(monsterChoice);
    }
    else
    {
        Console.WriteLine("Wrong choice. Choose a Goblin.");
        enemy = MonsterFactory.Create(1);
    }

    var logger = new BattleLogger();
    var engine = new BattleEngine(logger);

    Console.WriteLine("\nPress Enter to start to battle...");
    Console.ReadLine();

    ICharacter winner = engine.StartBattle(hero, enemy);

    Console.WriteLine("\nShow full log of the battle? [y/n]: ");
    if (Console.ReadLine()?.Trim().ToLower() == "y")
        logger.PrintFullLog();

    Console.WriteLine("\nPlay again? [y/n]: ");
    playAgain = Console.ReadLine()?.Trim().ToLower() == "y";
}

Console.WriteLine("\n   ⚔️ Thank you for game! See you soon.");

static void PrintWelcome()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;

    Console.WriteLine(@"
    
    
            RPG
        Battle Simulator
    
    ");
    Console.ResetColor();
}