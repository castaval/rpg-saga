public class Archer : IPlayer
{
    public string Name { get; set; }
    public int Strength { get; set; } 
    public int Health { get; set; }
    public int FullHealth { get; set; }
    public IAbility Ability { get; set; }
    public IEffect MyEffect { get; set; }
    public IEffect NormalState { get; set; }


    public Archer(string name, int strength, int health)
    {
        Name = name;
        Strength = strength;
        Health = health;

        FullHealth = Health;

        Ability = new FireArrows();
        NormalState = new Normal(Strength, Health);
        MyEffect = NormalState;
    }
    
    public void TakingDamage(int damage)
    {
        Health -= damage;
    }

    public void AttackEnemy(IPlayer enemy)
    {
        enemy.TakingDamage(Strength);
    }

    public void Ultimate(IPlayer myself, IPlayer enemy)
    {
        Ability.Spell(myself, enemy);
    }

    public void Effect(IPlayer myself)
    {
        MyEffect.State(myself);
    }

}