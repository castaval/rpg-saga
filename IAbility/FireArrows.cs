public class FireArrows : IAbility
{
    // public int Round { get; set; }

    public void Spell(IPlayer myself, IPlayer enemy, int round)
    {
        enemy.MyEffect = new LongDamage(5, round);
    }
}
