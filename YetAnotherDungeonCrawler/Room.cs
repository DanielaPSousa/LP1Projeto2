using System;
using System.Collections.Generic;

public class Room
{
    public string Description { get; set; }
    public Dictionary<string, Room> Exits { get; private set; }
    public Enemy Enemy { get; set; }
    public Item Item { get; set; }
    public SparklyChest Treasure { get; set; }

    public Room(string description)
    {
        Description = description;
        Exits = new Dictionary<string, Room>();
    }   
}