public interface IPlayer
{
    string Name { get; set; }
    int Strength { get; set; }
    int Health { get; set; }
    IAbility Ability { get; set; }
    IEffect? MyEffect { get; set; }
    IEffect NormalState { get; set; }
    string ClassName { get; set; }
    void Action(IPlayer myself, IPlayer enemy, int round);
    void TakingDamage(int damage);
    void AttackEnemy(IPlayer enemy);
    void Ultimate(IPlayer myself, IPlayer enemy, int round);
    void Effect(IPlayer myself);
    void DeleteEffect(IPlayer myself, int round);
    void RestoreAfterBattle();


}