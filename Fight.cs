public class Fight
{   
    private IPlayer FirstPlayer { get; set; }
    private IPlayer SecondPlayer { get; set; }
    List <IPlayer> AllPlayers { get; set; }

    public Fight(IPlayer firstPlayer, IPlayer secondPlayer, ref List<IPlayer> allPlayers)
    {
        FirstPlayer = firstPlayer;
        SecondPlayer = secondPlayer;
        AllPlayers = allPlayers;
    }

    public void Battle()
    {
        Random rand = new Random();
        while (true)
        {
            FirstPlayer.MyEffect.State(FirstPlayer);

            if (IsDefeat(FirstPlayer))
            {
                break;
            }

            if (rand.Next(0, 2) > 0)
            {
                FirstPlayer.AttackEnemy(SecondPlayer);
            }
            else
            {
                FirstPlayer.Ultimate(FirstPlayer, SecondPlayer);
            }

            if (IsDefeat(SecondPlayer))
            {
                break;
            }

            SecondPlayer.MyEffect.State(SecondPlayer);

            if (IsDefeat(SecondPlayer))
            {
                break;
            }

            if (rand.Next(0, 2) > 0)
            {
                SecondPlayer.AttackEnemy(FirstPlayer);
            }
            else
            {
                SecondPlayer.Ultimate(SecondPlayer, FirstPlayer);
            }

            if (IsDefeat(FirstPlayer))
            {
                break;
            }

        }
    }

    private bool IsDefeat(IPlayer player)
    {
        if (player.Health <= 0)
        {
            AllPlayers.Remove(player);
            return true;
        }
        
        return false;
    }
}