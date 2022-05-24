public interface IPlayer
{
    string Name { get; set; }
    int Strength { get; set; }
    int Health { get; set; }
    List <IAbility> Abilities { get; set; }
    List <IEffect> MyEffects { get; set; }
    IEffect NormalState { get; set; }
    string ClassName { get; set; }
    void TakingDamage(int damage);
    void AttackEnemy(IPlayer enemy);
    int Ultimate(IPlayer myself, IPlayer enemy, int round);
    void Effect(IPlayer myself);
    void DeleteEffect(IPlayer myself, int round, int numberPlayer);
    void RestoreAfterBattle();


}