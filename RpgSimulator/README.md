# ⚔️ RPG Battle Simulator (Console Pet Project)
A console-based turn-based combat simulator developed in C# and .NET 10.0. The project was created to demonstrate object-oriented programming (OOP) skills, application of SOLID principles, and design patterns.

## ✅ Key Features
* Class system: Choose a hero from several archetypes (Warrior, Mage, Archer, Paladin), each with their own uniquie characteristics and logic.    
* Ability System: Use active skills (Fireball, Multi-shot, Rage, etc.) that consume resources (mana, rage, holy power).
* Artificial Intelligence: Enemies (Goblins, Orcs, Dragons) make decisions in combat, using basic attacks or healing abilities depending on the situation.
* Interactive Logger: Detailed battle progress tracking with color indicators in the console and summary statistics.
* Status System: Supports effects (e.g., freeze) that affect gameplay.

## 🛠️ Tech Stack
* Language: C# 13
* Platform: .NET 10.0
* Tools: CLI, VS CODE

## 🏗 Architecture and Design
The project was designed with an emphasis on extensibility and code cleanliness.

 ### SOLID Principles
* S (Single Responsibility): Logic is separated into responsibilities: the BattleEngine manages the combat cycle, the BattleLogger is responsible for displaying information, and the CharacterFactory is responsible for object creation.   
* O (Open/Closed): The ability system is implemented through the IAbility interface. Adding a new ability does not require changing existing character code or the combat engine.
* L (Liskov Substitution): All characters (heroes and monsters) inherit from the Character base class and implement the ICharacter interface, allowing the combat engine to work with any entity consistently.
* I (Interface Segregation): Separating interfaces into ICharacter, IAbility, and IStatusEffectable allows objects to implement only the functionality they need.
* D (Dependency Inversion): The BattleEngine depends on abstractions rather than concrete implementations of character classes or abilities.

 ### Design patterns
* Simple Factory: The CharacterFactory and MonsterFactory classes encapsulate the logic for creating different character types.
* Strategy: Each ability implements the IAbility interface, representing a separate strategy for turn-based behavior.
* Observer (Events): BattleLogger subscribes to character events (OnDamaged, OnHealed, OnDeath), allowing combat logic to be separated from visualization.
* Template Method: The base Character class defines a general attack algorithm, delegating damage calculation (CalculateDamage) and message generation (GetAttackMessage) to its descendants.

## 💻 How to run
1. Make sure you have the .NET 10 SDK (or a compatible one) installed.
2. Clone the repository.
3. Go to the project folder:
```bash
cd RpgSimulator
```
4. Run project
```bash
dotnet run
```
## 📝 Development Plans
* Adding an inventory and equipment system.
* Implementing more complex status effects (poisoning, burning).
* Adding unit tests (xUnit) to check damage balance.
* Transition to storing character data in JSON/PostgreSQL. 
