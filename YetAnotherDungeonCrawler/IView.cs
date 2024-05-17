using System;

public class IView
{
    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void DisplayRoomInfo(Room room)
    {
        Console.WriteLine($"You are in:  {room.Description}.");
        if (room.Enemy != null)
        {
            Console.WriteLine("Há um inimigo aqui!");
        }
        if (room.Item != null)
        {
            Console.WriteLine("Há um item aqui!");
        }
        if (room.Treasure != null)
        {
            Console.WriteLine("Há um Sparklychest aqui!");
        }
    }

    public void DisplayPlayerInfo(Player player)
    {
        Console.WriteLine($"Player Health: {player.Health}, Attack Power: {player.AttackPower}, Coins: {player.Coins}");
    }
}