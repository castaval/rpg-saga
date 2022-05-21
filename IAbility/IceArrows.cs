public class IceArrows : IAbility
{
    public void Spell(IPlayer myself, IPlayer enemy)
    {
        enemy.State = Effect.Stiffen;
    }
}
