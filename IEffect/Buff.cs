public class Buff : IEffect
{
    public double Factor { get; set; }

    public int LastUsedRound { get; set; }

    public Buff(double factor, int round)
    {
        Factor = factor;
        LastUsedRound = round;
    }

    public void State(IPlayer Player)
    {
        Player.Strength = (int)((double)Player.Strength * Factor);
    }

    public void DeleteState(IPlayer Player, int Round, int numberPlayer)
    {
        if (Round - LastUsedRound == 1)
        {
            Player.MyEffect = Player.NormalState;
            if (Player.MyEffect is Normal normal) normal.RestoreStrength(Player);
            Player.MyEffect = null;
        }
    }
}