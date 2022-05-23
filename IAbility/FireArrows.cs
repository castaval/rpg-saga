public class FireArrows : IAbility
{
    // public int Round { get; set; }
    public string AbilityName { get; set; } = "Огненные стрелы";
    public void Spell(IPlayer myself, IPlayer enemy, int round)
    {
        enemy.MyEffect = new LongDamage(5, round);
    }
}
