using System;
/// <summary>
/// Class that represents an existing item.
/// </summary>
public abstract class Item
{
    public string Name { get; set; }
    /// <summary>
    /// Constructor for class item that sets the name of the item.
    /// </summary>
    /// <param name="name">Name of the item.</param>
    public Item(string name)
    {
        Name = name;
    }
}
/// <summary>
/// Class that implements the health potion, which is a type of item that is available in the game.
/// </summary>
public class HealthPotion : Item
{
    public int HealAmount { get; set; }
    /// <summary>
    /// Constructor of the HealthPotion class that defines the initial amount of health points that the potion restores.
    /// </summary>
    /// <param name="healAmount">Amount of health points that can be restored by drinking (using) the potion.</param>
    public HealthPotion(int healAmount) : base("Health Potion")
    {
        HealAmount = healAmount;
    }
}
/// <summary>
/// Class that implements the sparkly chest, which is a type of item that is available in the game.
/// </summary>
public class SparklyChest : Item
{
    public int Coins { get; private set; }
    /// <summary>
    /// Constructor of the SparklyChest class that defines the amount of coins contained in the chest.
    /// </summary>
    /// <param name="coins">Amount of coins to be given to the player that opens (uses) the chest.</param>
    public SparklyChest(int coins) : base("Super Sparkly Chest")
    {
        Coins = coins;
    }
}
    
