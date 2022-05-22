public class FireArrows : IAbility
{
    public void Spell(IPlayer myself, IPlayer enemy)
    {
        enemy.MyEffect = new LongDamage(5);
    }
}
