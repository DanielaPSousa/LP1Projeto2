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
                consoleView.DisplayMessage("Você derrotou o inimigo!");
                player.GainCoins(10);
                player.CurrentRoom.Enemy = null;
            }
            else
            {
                consoleView.DisplayMessage("O inimigo ainda está vivo.");
            }
        }
        else
        {
            consoleView.DisplayMessage("Não há inimigos nesta sala.");
        }
        consoleView.DisplayPlayerInfo(player);
    }

    public void PickUpItem()
{

    if (player.CurrentRoom.Item != null)
    {
        player.PickUpItem(player.CurrentRoom.Item);
        
        consoleView.DisplayMessage("Você apanhou o item.");
        
        player.CurrentRoom.Item = null;
    }
    else if (player.CurrentRoom.Treasure != null)
    {
        player.PickUpItem(player.CurrentRoom.Treasure);
        
        consoleView.DisplayMessage("Parabéns! Você conseguiu apanhar o Super Sparkly Chest!");
        
        player.CurrentRoom.Treasure = null;
    }
    else
    {
        consoleView.DisplayMessage("Não há itens nesta sala.");
    }

    consoleView.DisplayPlayerInfo(player);
}