public interface IAbility
{   
    // int Round { get; set; }

    void Spell(IPlayer myself, IPlayer enemy, int round);
}