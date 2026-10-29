using System.Text.Json;
using System.Text.Json.Serialization;

public class Player : IGameCharacter, ISaveable
{
    private string name;
    private int level;
    private int health;
    private List<Item> inventory = new List<Item>();
    public string Name
    {
        get
        {
            return name;
        }

    }

    public int Level
    {
        get
        {
            return level;
        }
    }

    public int Health
    {
        get
        {
            return health;
        }
    }

    // Creating a NEW player
    public Player(string name)
    {
        this.name = name;
        this.level = 1;
        this.health = 100;
    }

    [JsonConstructor] 
    // Rebuilding a SAVED player
    public Player(string name, int level, int health, IReadOnlyList<Item> inventory)
    {
        this.name = name;
        this.level = level;
        this.health = health;
        this.inventory = inventory.ToList();
    }
    public void AddItem(Item item)
    {
        inventory.Add(item);
    }


    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0)
        {
            health = 0;
        }
    }

    public void LevelUp()
    {
        level++;
    }

    public string ToJson()
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        return JsonSerializer.Serialize(this, options);
    }

    public IReadOnlyList<Item> Inventory
    {
        get
        {
            return inventory.AsReadOnly();
        }

    }
}