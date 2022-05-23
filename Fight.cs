public class Fight
{
    private ILogger Logger { get; set; }
    private IPlayer FirstPlayer { get; set; }
    private IPlayer SecondPlayer { get; set; }
    private int round { get; set; } = 1;
    List <IPlayer> AllPlayers { get; set; }

    public Fight(IPlayer firstPlayer, IPlayer secondPlayer, ref List<IPlayer> allPlayers, ILogger logger)
    {
        FirstPlayer = firstPlayer;
        SecondPlayer = secondPlayer;
        AllPlayers = allPlayers;
        Logger = logger;
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
        Logger.PrintEffect(playerGame);

        if (IsDefeat(playerGame, playerWait))
        {
            stopGame = true;
            return stopGame;
        }

        if (!(playerGame.MyEffect is Stun))
        {
            if (rand.Next(0, 3) > 0)
            {
                playerGame.AttackEnemy(playerWait);
                Logger.PrintAttack(playerGame, playerWait);

            }
            else
            {
                playerGame.Ultimate(playerGame, playerWait, round);
                Logger.PrintUltimate(playerGame, playerWait);
            }
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
            Logger.PrintDefeat(loser);
            AllPlayers.Remove(loser);
            winner.RestoreAfterBattle();
            return true;
        }

        return false;
    }
}