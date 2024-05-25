using System;
using System.Collections.Generic;

/// <summary>
/// Class that implements the game controller according to the MVC design pattern, containing the initialization function and the game loop.
/// </summary>
public class Controller
{
    private Player player;
    private List<Room> dungeon;
    private IView consoleView;
    /// <summary>
    /// Constructor of the Controller class that calls the initialization function.
    /// </summary>
    public Controller()
    {
        InitializeGame();
    }
    /// <summary>
    /// Function that initializes the game, creating a new player and a set of connected rooms (map) containing multiple enemies and items. The starting room for the player is also defined.
    /// </summary>
    private void InitializeGame()
    {
        player = new Player(100, 10);

        Room room1 = new Room("Starting room! It seems like many have entered and never returned...");
        Room room2 = new Room("Enemy room! Inside this room, illuminated by only two torches, you realise that many have fallen here.");
        Room room3 = new Room("Room with a healing potion! Looks like whoever was in this room many years ago, used to work here as a scientist.");
        Room room4 = new Room("Enemy room! At first, this room seems ordinary, only illuminated by a lantern on the roof. Then you realise there's swords and shields scattered across the room.");
        Room room5 = new Room("Room with a healing potion! This seems to have been a dining room. Many bottles were left on top of a table, including a healing potion!");
        Room room6 = new Room("Boss room! As an ear-pirecing roar fills the room, an enormous, horrifying skeleton with a shield and a sword appears in front of you, ready to fight.");
        Room room7 = new Room("Secret room! This seems to be where all the gold and silver was kept. Many glowing goods are still here, intact! There is a golden chest decorated with rubis, at the end of the room.");
        Room room8 = new Room("Storage room! This seems to be where whoever was here used to store huge packages. Some doors are blocked by debris.");
        Room room9 = new Room("Old library! There are a lot of books scattered in the ground, and many shelves are covered in spider webs. Many doors to this room are closed, and seem impossible to open.");

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
    /// <summary>
    /// Function that starts the game by setting the user interface, welcoming the player, and calling the game's loop function.
    /// </summary>
    /// <param name="view">Instance of the user interface class.</param>
    public void StartGame(IView view)
    {
        consoleView = view;
        consoleView.DisplayMessage("Welcome, you are a brave soul who wants to explore an old dungeon and find the treasures it might contain.");
        DisplayCurrentRoom();
        MainLoop(); 
    }
    /// <summary>
    /// Function that requests for the user interface to show the information of the current room, where the player is located.
    /// </summary>
    private void DisplayCurrentRoom()
    {
        consoleView.DisplayRoomInfo(player.CurrentRoom);
    }
    /// <summary>
    /// Function that maintains the game logic sequence, allowing the player to move between rooms, fight enemies and pick up items.
    /// </summary>
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
                consoleView.DisplayMessage("You're been defeated. This is the end of the road...");
                playing = false;
            }
        }
        consoleView.DisplayMessage("Logging off..Thank you for playing!");
    }
    /// <summary>
    /// Function that simulates the movement of the player from the current room to another room, through an exit, if possible.
    /// </summary>
    public void MovePlayer()
    {
        if (player.CurrentRoom.Enemy != null && player.CurrentRoom.Enemy.Health > 0)
        {
            consoleView.DisplayMessage("You can't leave until the enemy is defeated!");
            return;
        }

        consoleView.DisplayMessage("Where do you want to go? Options: " + string.Join(", ", player.CurrentRoom.Exits.Keys));
        string direction = Console.ReadLine().ToLower();
        if (player.CurrentRoom.Exits.ContainsKey(direction))
        {
            Room newRoom = player.CurrentRoom.Exits[direction];
            player.Move(newRoom);
            DisplayCurrentRoom();
        }
        else
        {
            consoleView.DisplayMessage("There's nothing but a wall that way!");
        }
    }
    /// <summary>
    /// Function that implements an attack of the player to the enemy that is located in the player's current room.
    /// </summary>
    public void AttackEnemy()
    {
        if (player.CurrentRoom.Enemy != null)
        {
            player.Attack(player.CurrentRoom.Enemy);
            if (player.CurrentRoom.Enemy.Health <= 0)
            {
                consoleView.DisplayMessage("You defeated the enemy! As it falls, you breathe a sigh of relief. Good job!");
                player.GainCoins(10);
                player.CurrentRoom.Enemy = null;
            }
            else
            {
                consoleView.DisplayMessage("The enemy is still alive, and attacks!");
            }
        }
        else
        {
            consoleView.DisplayMessage("There are no enemies in this room.");
        }
        consoleView.DisplayPlayerInfo(player);
    }
    /// <summary>
    /// Function that implements the action of picking up an item, available on the player's current room, and receiving it's effects.
    /// </summary>
    public void PickUpItem()
    {

        if (player.CurrentRoom.Item != null)
        {
            player.PickUpItem(player.CurrentRoom.Item);
            consoleView.DisplayMessage("You drank the potion. Health restored!");
            player.CurrentRoom.Item = null;
        }
        else if (player.CurrentRoom.Treasure != null)
        {
            player.PickUpItem(player.CurrentRoom.Treasure);
            consoleView.DisplayMessage("Congratulations! You managed to find the rare Super Sparkly Chest!");
            player.CurrentRoom.Treasure = null;
        }
        else
        {
            consoleView.DisplayMessage("There are no items in this room.");
        }
        consoleView.DisplayPlayerInfo(player);
    }
}