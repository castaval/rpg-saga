public class Buff : IEffect
{   
    public int Factor { get; set; }

    public Buff(int factor)
    {
        Factor = factor;
    }

    public void State(IPlayer Player)
    {
        Player.Strength = Player.Strength * Factor;
    }
}