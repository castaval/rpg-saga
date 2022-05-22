public class Game
{
    private string[] playerNames = {"Nikita", "Stanislav", "Oleg", "Danila", "Alexey", "Michael", "Max", "Ivan", "Nazar", "Kevin", "Vladislav"};

    public void Run()
    {   
        PlayersGenerator playersGenerator = new PlayersGenerator(10, playerNames);
    
        List<IPlayer> players = new List<IPlayer>(playersGenerator.GeneratePlayersArray());        
        
        while (true)
        {   
            // Logger.LogKone();
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
                Fight fight = new Fight(players[i], players[i+1], ref players);
                fight.Battle();
            } 
        }
    }

    public bool EndGame(List <IPlayer> players)
    {
        if (players.Count == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}