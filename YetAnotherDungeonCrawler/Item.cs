using System;

public abstract class Item
{
    public string Name { get; set; }
    public Item(string name)
    {
        Name = name;
    }

    public class HealthPotion : Item
    {
        public int HealAmount { get; set; }
        public HealthPotion(int healAmount) : base("Health Potion")
        {
            HealAmount = healAmount;
        }
    }
}