using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Title = "Yet Another Dungeon Crawler";
        Controller gameController = new Controller();
        IView view = new IView();
        gameController.StartGame(view);
    }
}