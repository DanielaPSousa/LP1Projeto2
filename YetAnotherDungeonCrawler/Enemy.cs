/// <summary>
/// Class that implements an enemy NPC.
/// </summary>
public class Enemy
{
    public int Health { get; set; }
    public int AttackPower { get; private set; }
    /// <summary>
    /// Constructor of the enemy class that sets it's initial health and attack power.
    /// </summary>
    /// <param name="health">Amount of initial health points.</param>
    /// <param name="attackPower">Amount of attack power the enemy has.</param>
    public Enemy(int health, int attackPower)
    {
        Health = health;
        AttackPower = attackPower;
    }
    /// <summary>
    /// Function that simulates an attack on a given player, decreasing the amount of the player's health points according to the enemy's attack power.
    /// </summary>
    /// <param name="player">Player to be attacked.</param>
    public void Attack(Player player)
    {
        player.Health -= AttackPower;
    }
}