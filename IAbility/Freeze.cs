public class Freeze : IAbility
{
    // public int Round { get; set; }
    public string AbilityName { get; set; } = "Заворожение";
    public void Spell(IPlayer myself, IPlayer enemy, int round)
    {
        enemy.MyEffects.Add(new Stun(round));
        // enemy.Effect(enemy);
    }
}
