public class Enemy
{
    public int Health { get; set; }
    public int AttackPower { get; private set; }

    public Enemy(int health, int attackPower)
    {
        Health = health;
        AttackPower = attackPower;
    }

    public void Attack(Player player)
    {
        player.Health -= AttackPower;
    }
}