public class Normal : IEffect
{
    public int Health { get; set; }
    public int Strength { get; set; }

    public Normal(int strength, int health)
    {
        Health = health;
        Strength = strength;
    }

    public void State(IPlayer myself)
    {
        myself.Health = Health;
        myself.Strength = Strength;
    }
}