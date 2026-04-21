namespace RpgSimulator.Core;

public abstract class Character : ICharacter
{
    public string Name {get; private set;}
    public int Health {get; private set;}
    public int MaxHealth {get; private set;}
    public bool IsAlive => Health > 0;

    protected int BaseDamage {get; set;}
    protected int Defense {get; set;}
    protected List<Ability> Abilities {get;}= new();

    public event Action<ICharacter>? OnDeath;
    public event Action<ICharacter, int>? OnDamaged;
    public event Action<ICharacter, int>? OnHealed;

    protecter Character(string name, int maxHealth, int baseDamage,int defense = 0)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Character Name cannot be empty.");
        }
        if(maxHealth <= 0)
        {
            throw new ArgumentException("HP must be greater zero.");
        }

        Name = name;
        Health = maxHealth;
        MaxHealth = maxHealth;
        BaseDamage = baseDamage;
        Defense = defense;

        RegiterAbilities();
    }

    public void Attack(ICharacter target)
    {

        if (!IsAlive)
        {
            Console.WriteLine($"{Name} is dead and can't attack");
            return;
        }

        int damage = CalculateDamage();
        Console.WriteLine(GetAttackMessage(target));
        target.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        if(!IsAlive) return;

        int actualDamage = Math.Max(1, damage - Defense);
        Health = Math.Max(0, Health - actualDamage);

        OnDamaged?.Invoke(this, actualDamage);
        if (!IsAlive)
        {
            OnDeath?.Invoke(this);
        }
    }
    protected void Heal(int amount)
    {
        if (!IsAlive) return;

        int actualHeal  = Math.Min(amount, MaxHealth - Health);
        Health += actualHeal;
        OnHealed?.Invoke(this, actualHeal);
    }
    public void ShowAbilities()
    {
        Console.WriteLine($"\n Abilities {Name}");
        if(Abilities.Count == 0)
        {
            Console.WriteLine(" No abilities.");
            return;
        }
        for(int i = 0; i < Abilities.Count; i++)
        {
            var a = Abilities[i];
            Console.WriteLine($"[{i+1}] {a.Name} (mana: {a.ManaCost}) - {a.Description}");
        }
    }
    public IReadOnlyList<IAbility> GetAbilities() => Abilities.AsReadOnly();

    public virtual void ShowStats()
    {
        string hpBar = BuildHpBar();
        Console.WriteLine($"  {Name, -15} | {hpBar} {Health}/{MaxHealth} HP | Damage: {BaseDamage} | Defense: {Defense}");
    }

    protected abstract int CalculateDamage();
    protected abstract string GetAttackMessage(ICharacter target);
    protected abstract void RegiterAbilities();

    private string BuildHpBar()
    {
        int barLength = 10;
        int filled = (int)Math.Round((double)Health / MaxHealth * barLength);
        string bar = new string("\u001b[32m\u2588\u001b[0m", filled) + new string("\u2591", barLength - filled);

        return Health > MaxHealth * 0.5 ? $"[\u001b[32m{bar}\u001b[0m]" 
                : Health > MaxHealth * 0.2 ? $"[u001b[33m{bar}\u001b[0m]" 
                : $"[\u001b[31m{bar}\u001b[0m]";
    }

}

