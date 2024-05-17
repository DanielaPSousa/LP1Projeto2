using System;
using System.Collections.Generic;

public class Controller
{
    private Player player;
    private List<Room> dungeon;
    private IView consoleView;

    public Controller()
    {
        consoleView = new IView();
        InitializeGame();
    }
    private void InitializeGame()
    {
        player = new Player(100, 10);

        Room room1 = new Room("Sala Inicial-Tutorial");
        Room room2 = new Room("Sala com Inimigo");
        Room room3 = new Room("Sala com Poção de Cura");
        Room room4 = new Room("Sala com Inimigo");
        Room room5 = new Room("Sala com Poção de Cura");
        Room room6 = new Room("Sala com um Boss");
        Room room7 = new Room("Sala da Recompensa");
        Room room8 = new Room("Sala Vazia");
        Room room9 = new Room("Sala Vazia");

        room1.SetExit("north", room2);
        room2.SetExit("south", room1);
        room2.SetExit("east", room3);
        room3.SetExit("west", room2);
        room3.SetExit("south", room4);
        room4.SetExit("north", room3);
        room4.SetExit("east", room5);
        room5.SetExit("west", room4);
        room5.SetExit("north", room6);
        room6.SetExit("north", room7);
        room2.SetExit("north", room8);
        room8.SetExit("south", room2);
        room4.SetExit("south", room9);
        room9.SetExit("north", room4);

        room1.Enemy = new Enemy(10, 2); 
        room2.Enemy = new Enemy(30, 5);
        room3.Item = new HealthPotion(20);
        room4.Enemy = new Enemy(50, 8); 
        room5.Item = new HealthPotion(30);
        room6.Enemy = new Enemy(70, 10); 
        room7.Treasure = new SparklyChest(1000);

        player.CurrentRoom = room1;
        dungeon = new List<Room> { room1, room2, room3, room4, room5, room6, room7, room8, room9}; 
    }
    
    public void StartGame()
    {
        consoleView.DisplayMessage("Welcome..You are a brave soul who wants to explore the old dungeon and get the treasures it contains.");
        DisplayCurrentRoom();
        MainLoop(); 
    }
    private void DisplayCurrentRoom()
    {
        consoleView.DisplayRoomInfo(player.CurrentRoom);
    }
        private void MainLoop()
    {
        bool playing = true;
        while (playing)
        {
            consoleView.DisplayMessage("What do you want to do? (move, attack, pickup, exit)");
            string command = Console.ReadLine().ToLower();
            switch (command)
            {
                case "move":
                    MovePlayer();
                    break;
                case "attack":
                    AttackEnemy();
                    break;
                case "pickup":
                    PickUpItem();
                    break;
                case "exit":
                    playing = false;
                    break;
                default:
                    consoleView.DisplayMessage("Wrong bottom!!");
                    break;
            }
            if (player.Health <= 0)
            {
                consoleView.DisplayMessage("You're dead. This is the end of the road...");
                playing = false;
            }
        }
        consoleView.DisplayMessage("Logging off..Thank you for playing!");
    }

    public void AttackEnemy()
    {
        if (player.CurrentRoom.Enemy != null)
        {
            player.Attack(player.CurrentRoom.Enemy);
            if (player.CurrentRoom.Enemy.Health <= 0)
            {
                consoleView.DisplayMessage("You defeated the enemy good job!");
                player.GainCoins(10);
                player.CurrentRoom.Enemy = null;
            }
            else
            {
                consoleView.DisplayMessage("The enemy is still alive..");
            }
        }
        else
        {
            consoleView.DisplayMessage("There are no enemies in this room");
        }
        consoleView.DisplayPlayerInfo(player);
    }

    public void PickUpItem()
{

    if (player.CurrentRoom.Item != null)
    {
        player.PickUpItem(player.CurrentRoom.Item);
        
        consoleView.DisplayMessage("You picked up an item");
        
        player.CurrentRoom.Item = null;
    }
    else if (player.CurrentRoom.Treasure != null)
    {
        player.PickUpItem(player.CurrentRoom.Treasure);
        
        consoleView.DisplayMessage("Congratulations! You managed to get the Super Sparkly Chest!");
        
        player.CurrentRoom.Treasure = null;
    }
    else
    {
        consoleView.DisplayMessage("There are no items in this room");
    }
    consoleView.DisplayPlayerInfo(player);
    }
}