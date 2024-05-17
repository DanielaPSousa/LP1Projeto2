using System;

public class IView
{
    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void DisplayRoomInfo(Room room)
    {
        Console.WriteLine($"You are in {room.Description}.");
        if (room.Enemy != null)
        {
            Console.WriteLine("There is an enemy here!");
        }
        if (room.Item != null)
        {
            Console.WriteLine("There is a potion here!");
        }
        if (room.Treasure != null)
        {
            Console.WriteLine("There is a Sparklychest here!");
        }
    }

    public void DisplayPlayerInfo(Player player)
    {
        Console.WriteLine($"Player Health: {player.Health}, Attack Power: {player.AttackPower}, Coins: {player.Coins}");
    }
}