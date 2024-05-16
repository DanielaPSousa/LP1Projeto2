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
}