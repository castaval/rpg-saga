public class FireArrows : IAbility
{
    public void Spell(IPlayer myself, IPlayer enemy)
    {
        enemy.State = Effect.Burn;
    }
}
