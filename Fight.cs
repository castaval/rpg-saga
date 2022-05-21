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
        FirstPlayer.MyState.State(FirstPlayer);
        FirstPlayer.AttackEnemy(SecondPlayer);

        SecondPlayer.MyState.State(SecondPlayer);
        SecondPlayer.AttackEnemy(FirstPlayer);
    }
}