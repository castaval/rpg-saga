public class Fireball : IAbility
{
    // public int Round { get; set; }
    public string AbilityName { get; set; } = "Фаерболл";
    public void Spell(IPlayer myself, IPlayer enemy, int round)
    {
        IEffect generateBuff = new Buff(2, round);
        myself.MyEffects.Add(generateBuff);
        int indexEffect = myself.MyEffects.IndexOf(generateBuff);
        myself.MyEffects[indexEffect].State(myself);
        enemy.Health -= myself.Strength;
    }
}
