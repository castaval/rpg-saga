public class Freeze : IAbility
{
    // public int Round { get; set; }

    public void Spell(IPlayer myself, IPlayer enemy, int round)
    {
        enemy.MyEffect = new Stun(round);
        enemy.Effect(enemy);
    }
}
