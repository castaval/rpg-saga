public class Freeze : IAbility
{
    public void Spell(IPlayer myself, IPlayer enemy)
    {
        // enemy.MyState = Effect.Stunned;
        enemy.MyState = new Stun();
    }
}
