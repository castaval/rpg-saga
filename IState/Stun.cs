public class Stun : IEffect
{
    public void State(IPlayer myself)
    {
        myself.Strength = 0;
    }
}