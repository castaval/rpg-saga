public class Fireball : IAbility
{
    public void Spell(IPlayer myself, IPlayer enemy)
    {
        myself.MyEffect = new Buff(2);
    }
}
