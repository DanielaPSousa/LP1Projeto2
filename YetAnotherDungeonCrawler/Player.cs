using System;

public class Player
{
    public int Health { get; set; }
    public int AttackPower { get; private set; }
    public Room CurrentRoom { get; set; }
    public int Coins { get; private set; }

    public Player(int health, int attackPower)
    {
        Health = health;           
        AttackPower = attackPower; 
        Coins = 0;                 
    }

    public void Move(Room newRoom)
    {
        CurrentRoom = newRoom;
    }

    public void Attack(Enemy enemy)
    {
        enemy.Health -= AttackPower;
        
        if (enemy.Health > 0)
        {
            Health -= enemy.AttackPower;
        }
    }

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

    public void GainCoins(int amount)
    {
        Coins += amount;
    }

}