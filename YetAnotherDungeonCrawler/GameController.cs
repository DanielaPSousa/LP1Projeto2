using System;
using System.Collections.Generic;

public class GameController
{
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