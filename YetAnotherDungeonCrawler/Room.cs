using System;
using System.Collections.Generic;
/// <summary>
/// Class that implements a room that can contain enemies and items inside. A room can also have multiple exits to other rooms.
/// </summary>
public class Room
{
    public string Description { get; set; }
    public Dictionary<string, Room> Exits { get; private set; }
    public Enemy Enemy { get; set; }
    public Item Item { get; set; }
    public SparklyChest Treasure { get; set; }
    /// <summary>
    /// Constructor of the room class that stores the room description and creates a memory structure for the possible exits.
    /// </summary>
    /// <param name="description">Description of the room in a string format.</param>
    public Room(string description)
    {
        Description = description;
        Exits = new Dictionary<string, Room>();
    }  
    /// <summary>
    /// Function that adds a new exit to a given room.
    /// </summary>
    /// <param name="direction">Cardinal point that is associated with the new exit, in a string format.</param>
    /// <param name="neighbor">Room that is right after the exit.</param>
    public void SetExit(string direction, Room neighbor)
    {
        Exits[direction] = neighbor;
    } 
}