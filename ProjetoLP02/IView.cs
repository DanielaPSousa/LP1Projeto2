using System;

public class IView
{
    public IView()
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Red;
        //Console.ResetColor();
    }
    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

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

    public void DisplayPlayerInfo(Player player)
    {
        Console.WriteLine($"Player Health: {player.Health}, Attack Power: {player.AttackPower}, Coins: {player.Coins}");
    }
    static void DrawHorizontalBar(string info)
    {
        // Set the console width
        int consoleWidth = Console.WindowWidth;

        // Save current cursor position
        int currentLeft = Console.CursorLeft;
        int currentTop = Console.CursorTop;

        // Set the cursor position to the top
        Console.SetCursorPosition(0, 0);

        // Set the background color for the bar
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;

        // Draw the bar
        Console.WriteLine(new string(' ', consoleWidth));

        // Set the cursor position to the start of the bar
        Console.SetCursorPosition(0, 0);

        // Print the info
        Console.Write(info.PadRight(consoleWidth - 1));

        // Reset colors
        Console.ResetColor();

        // Restore the cursor position
        Console.SetCursorPosition(currentLeft, currentTop);
    }
}