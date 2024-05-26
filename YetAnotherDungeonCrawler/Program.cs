using System;
/// <summary>
/// Class that implements the main function, from where the program starts running.
/// </summary>
public class Program
{
    /// <summary>
    /// Main function that sets up the game environment, according to the MVC design pattern.
    /// </summary>
    /// <param name="args">The program takes no arguments, but could be used as initial setup inputs (e.g. name of the file containing the room map) in the future.</param>
    public static void Main(string[] args)
    {
        Controller gameController = new Controller();
        gameController.StartGame();
    }
}