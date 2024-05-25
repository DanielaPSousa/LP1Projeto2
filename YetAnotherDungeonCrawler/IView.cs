using System;
/// <summary>
/// Class that implements the user interface for the game.
/// </summary>
public class IView
{
    /// <summary>
    /// Constructor of the user interface that defines the static text and background colors.
    /// </summary>
    public IView()
    {
        Console.Title = "Yet Another Dungeon Crawler";
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Red;
        //Console.ResetColor();
    }
    /// <summary>
    /// Function that displays a given message to the user on the terminal.
    /// </summary>
    /// <param name="message">Message to be displayed, in a string format.</param>
    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
    /// <summary>
    /// Function that displays all the information about a given room to the user on the terminal.
    /// </summary>
    /// <param name="room">Room instance from which the information to be displayed is extracted.</param>
    public void DisplayRoomInfo(Room room)
    {
        Console.WriteLine($"You are in the {room.Description}.");
        if (room.Enemy != null)
        {
            Console.WriteLine("An armored skeleton rises from the shadows and attacks!");
        }
        if (room.Item != null)
        {
            Console.WriteLine("There is a health potion here!");
        }
        if (room.Treasure != null)
        {
            Console.WriteLine("There is a Sparklychest here!");
        }
    }
    /// <summary>
    /// Function that displays all the information about a given player to the user on the terminal.
    /// </summary>
    /// <param name="player">Player instance from which the information to be displayed is extracted.</param>
    public void DisplayPlayerInfo(Player player)
    {
        Console.WriteLine($"Player Health: {player.Health}, Attack Power: {player.AttackPower}, Coins: {player.Coins}");
    }
}