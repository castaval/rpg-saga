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
            Player.MyEffect = null;
        }
    }    
}