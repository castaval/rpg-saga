public class Stun : IEffect
{
    public int LastUsedRound { get; set; }

    public Stun(int round)
    {
        LastUsedRound = round;
    }

    public void State(IPlayer Player)
    {
        Player.Strength = 0;
    }

    public void DeleteState(IPlayer Player, int Round)
    {
        if (Round - LastUsedRound == 1)
        {
            Player.MyEffect = Player.NormalState;
            if (Player.MyEffect is Normal normal) normal.RestoreStrength(Player);
            Player.MyEffect = null;
        }
    }
}