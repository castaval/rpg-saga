public class Fight
{   
    private IPlayer FirstPlayer { get; set; }
    private IPlayer SecondPlayer { get; set; }
    private int round = 1;
    List <IPlayer> AllPlayers { get; set; }

    public Fight(IPlayer firstPlayer, IPlayer secondPlayer, ref List<IPlayer> allPlayers)
    {
        FirstPlayer = firstPlayer;
        SecondPlayer = secondPlayer;
        AllPlayers = allPlayers;
    }

    public void Battle()
    {   
        bool stopGame;
        while (true)
        {
            stopGame = PlayerTurn(FirstPlayer, SecondPlayer);

            if (stopGame)
            {
                break;
            }

            stopGame = PlayerTurn(SecondPlayer, FirstPlayer);

            if (stopGame)
            {
                break;
            }

            round++;
        }
    }

    private bool PlayerTurn(IPlayer playerGame, IPlayer playerWait)
    {
        Random rand = new Random();
        bool stopGame = false;

        playerGame.DeleteEffect(playerGame, round);
        playerGame.Effect(playerGame);

        if (IsDefeat(playerGame, playerWait))
        {
            stopGame = true;
            return stopGame;
        }
        
        if (playerGame.MyEffect is Stun piska) // DOWNCAST BABY 
        {   
            playerGame.Action(playerGame, playerWait, round);
        }
        
        if (IsDefeat(playerWait, playerGame))
        {
            stopGame = true;
            return stopGame;
        }

        return stopGame;
    }

    private bool IsDefeat(IPlayer loser, IPlayer winner)
    {
        if (loser.Health <= 0)
        {
            AllPlayers.Remove(loser);
            winner.RestoreAfterBattle();
            return true;
        }
        
        return false;
    }
}