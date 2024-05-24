using System;

/// <summary>
/// Class that implements the player. The player has healthpoints, attackpower, an amount of coins and a room, where he is currently located.
/// </summary>
public class Player
{
    public int Health { get; set; }
    public int AttackPower { get; private set; }
    public Room CurrentRoom { get; set; }
    public int Coins { get; private set; }

    /// <summary>
    /// Constructor for the player class.
    /// </summary>
    /// <param name="health">Initial amount of healthpoints.</param>
    /// <param name="attackPower">Attack power defined for the player.</param>
    public Player(int health, int attackPower)
    {
        Health = health;           
        AttackPower = attackPower; 
        Coins = 0;                 
    }

    /// <summary>
    /// Function that associates a new room to the player, simulating the movement of the player to another room.
    /// </summary>
    /// <param name="newRoom">Room to where the player is going to move.</param>
    public void Move(Room newRoom)
    {
        CurrentRoom = newRoom;
    }

    /// <summary>
    /// Function that simulates an attack on an enemy, decreasing it's health according to the player's attack power.
    /// </summary>
    /// <param name="enemy">The enemy instance to be attacked.</param>
    public void Attack(Enemy enemy)
    {
        enemy.Health -= AttackPower;
        
        if (enemy.Health > 0)
        {
            Health -= enemy.AttackPower;
        }
    }

    /// <summary>
    /// Function that simulates the player picking up an item and suffering it's effects.
    /// </summary>
    /// <param name="item">Instance of the item to be picked.</param>
    public void PickUpItem(Item item)
    {
        if (item is HealthPotion potion)
        {
            Health += potion.HealAmount; 
        }
        else if (item is SparklyChest chest)
        {
            Coins += chest.Coins; 
        }
    }

    /// <summary>
    /// Function that increases the amount of coins owned by the player.
    /// </summary>
    /// <param name="amount">Amount of coins that the player received.</param>
    public void GainCoins(int amount)
    {
        Coins += amount;
    }

}