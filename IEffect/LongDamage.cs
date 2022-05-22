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

    public void DeleteState(IPlayer Player, int Round)
    {
        if (Round - LastUsedRound > 10)
        {
            Player.MyEffect = null;
        }
    }  
}