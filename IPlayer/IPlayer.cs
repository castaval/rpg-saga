public interface IPlayer
{
    string Name { get; set; }
    int Strength { get; set; }
    int Health { get; set; }
    int FullHealth { get; set; }
    IAbility Ability { get; set; }
    IEffect MyEffect { get; set; }
    IEffect NormalState { get; set; }

    void TakingDamage(int damage);
    void AttackEnemy(IPlayer enemy);
    void Ultimate(IPlayer myself, IPlayer enemy);
    void Effect(IPlayer myself);


}