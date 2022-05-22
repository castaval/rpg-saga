public class LongDamage : IEffect
{   
    public int Factor { get; set; }

    public LongDamage(int factor)
    {
        Factor = factor;
    }

    public void State(IPlayer enemy)
    {
        enemy.Health -= Factor;
    }
}