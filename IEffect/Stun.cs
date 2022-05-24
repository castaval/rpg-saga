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

    public void DeleteState(IPlayer Player, int Round, int numberPlayer)
    {
        if ((Round - LastUsedRound == 1 && numberPlayer == 2) || (Round - LastUsedRound == 2 && numberPlayer == 1))
        {
            if (Player.NormalState is Normal normal) normal.RestoreStrength(Player);
            foreach (var effect in Player.MyEffects.ToList())
            {
                if (effect is Stun stun)
                {
                    Player.MyEffects.Remove(stun);
                }
            }
        }
    }
}