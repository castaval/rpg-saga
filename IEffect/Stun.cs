public class Stun : IEffect
{   
    public void State(IPlayer Player)
    {
        Player.Strength = 0;
    }
}