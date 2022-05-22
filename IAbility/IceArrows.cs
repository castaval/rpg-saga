public class IceArrows : IAbility
{
    // public int Round { get; set; }

    public void Spell(IPlayer myself, IPlayer enemy, int round)
    {
        enemy.MyEffect = new LongDamage(10, round);
    }
}

