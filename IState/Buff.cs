public class Buff : IEffect
{
    public void State(IPlayer myself)
    {
        myself.Strength = 0;
    }
}