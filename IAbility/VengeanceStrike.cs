public class VengeanceStrike : IAbility
{
    public void Spell(IPlayer myself, IPlayer enemy)
    {
        myself.Strength = myself.Strength * 130 / 100;
    }
}
