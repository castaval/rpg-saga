public class Game
{
    private ILogger Logger { get; set; }
    private int numberTour { get; set; }

    public Game(ILogger GameLogger)
    {
        Logger = GameLogger;
        numberTour = 1;
    }

    private string[] playerNames = {"Nikita", "Stanislav", "Oleg", "Danila", "Alexey", "Michael", "Max", "Ivan", "Nazar", "Kevin", "Vladislav"};

    public void Run()
    {
        Logger.PrintStart();

        Selector selector = new Selector(Logger);

        List<bool> newClasses = selector.SelectCustomClass();

        int playerNumbers = selector.SelectNumbPlayers();

        PlayersGenerator playersGenerator = new PlayersGenerator(playerNumbers, playerNames, newClasses);

        List<IPlayer> players = new List<IPlayer>(playersGenerator.GeneratePlayersArray());

        while (true)
        {
            Logger.PrintTour(numberTour);
            numberTour++;

            Draw(players);
            Tour(players);

            if (EndGame(players))
            {
                break;
            }
        }
    }

    public void Draw(List <IPlayer> players)
    {
        Random random = new Random();
        for (int i = players.Count - 1; i >= 1; i--)
        {
            int j = random.Next(i + 1);
            var temp = players[j];
            players[j] = players[i];
            players[i] = temp;
        }
    }

    public void Tour(List <IPlayer> players)
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (i + 1 < players.Count)
            {
                Fight fight = new Fight(players[i], players[i+1], ref players, Logger);
                fight.Battle();
            }
        }
    }

    public bool EndGame(List <IPlayer> players)
    {
        if (players.Count == 1)
        {
            Logger.PrintEnd(players[0]);
            return true;
        }
        else
        {
            return false;
        }
    }


}