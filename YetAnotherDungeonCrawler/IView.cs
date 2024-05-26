using System;
/// <summary>
/// Class that implements the user interface for the game.
/// </summary>
public class IView
{
    /// <summary>
    /// Function that displays a given message to the user on the terminal.
    /// </summary>
    /// <param name="message">Message to be displayed, in a string format.</param>
    public void DisplayMessage(string message, ConsoleColor color = ConsoleColor.White)
    {
        Console.Title = "Yet Another Dungeon Crawler";
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
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
            Console.WriteLine("An armored skeleton rises from the shadows and attacks!", ConsoleColor.Red);
        }
        if (room.Item != null)
        {
            Console.WriteLine("There is a health potion here!", ConsoleColor.Green);
        }
        if (room.Treasure != null)
        {
            Console.WriteLine("There is a Sparkly chest here!", ConsoleColor.Yellow);
        }
        if (room.Exits.Count > 0)
        {
            DisplayMessage("Exits: " + string.Join(", ", room.Exits.Keys), ConsoleColor.Magenta);
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
    public void DisplayScoreAndMoves(int score, int moves)
    {
        int originalLeft = Console.CursorLeft;
        int originalTop = Console.CursorTop;
        int scorePositionLeft = Console.WindowWidth - 20;
        int scorePositionTop = 0;

        Console.SetCursorPosition(scorePositionLeft, scorePositionTop);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Score: {score}");
        Console.SetCursorPosition(scorePositionLeft, scorePositionTop + 1);
        Console.WriteLine($"Moves: {moves}");
        Console.ResetColor();
        Console.SetCursorPosition(originalLeft, originalTop);
    }
}