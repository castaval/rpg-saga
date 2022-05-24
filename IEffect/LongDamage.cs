public class LongDamage : IEffect
{
    public int Factor { get; set; }

    public int LastUsedRound { get; set; }


    public LongDamage(int factor, int round)
    {
        Factor = factor;
        LastUsedRound = round;
    }

    public void State(IPlayer enemy)
    {
        enemy.Health -= Factor;
    }

    public void DeleteState(IPlayer Player, int Round, int numberPlayer)
    {
        if ((Round - LastUsedRound == 10 && numberPlayer == 2) || (Round - LastUsedRound == 11 && numberPlayer == 1))
        {
            Player.MyEffect = null;
        }
    }
}