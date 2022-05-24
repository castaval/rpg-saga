public class Fireball : IAbility
{
    // public int Round { get; set; }
    public string AbilityName { get; set; } = "Фаерболл";
    public void Spell(IPlayer myself, IPlayer enemy, int round)
    {
        myself.MyEffect = new Buff(2, round);
        myself.MyEffect.State(myself);
        enemy.Health -= myself.Strength;
    }
}
