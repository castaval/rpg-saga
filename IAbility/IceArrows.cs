public class IceArrows : IAbility
{
    public void Spell(IPlayer myself, IPlayer enemy)
    {
        enemy.MyEffect = new LongDamage(10);
    }
}

