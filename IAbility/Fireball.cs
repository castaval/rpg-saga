public class Fireball : IAbility
{
    // public int Round { get; set; }

    public void Spell(IPlayer myself, IPlayer enemy, int round)
    {
        myself.MyEffect = new Buff(2, round);
        myself.MyEffect.State(myself);
        enemy.Health -= myself.Strength;
        myself.MyEffect = myself.NormalState;
        if (myself.MyEffect is Normal normal) normal.RestoreStrength(myself);
    }
}
