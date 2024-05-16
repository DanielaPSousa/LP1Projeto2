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
}