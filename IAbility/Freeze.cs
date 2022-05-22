public class Freeze : IAbility
{
    public void Spell(IPlayer myself, IPlayer enemy)
    {
        enemy.MyEffect = new Stun();
    }
}
