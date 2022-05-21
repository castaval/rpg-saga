public class Mage : IPlayer
{
    public string Name { get; set; }
    public int Strength { get; set; } 
    public int Health { get; set; }
    public int FullHealth { get; set; }
    public IAbility Ability { get; set; }
    public Effect State { get; set; }

    public Mage(string name, int strength, int health)
    {
        Name = name;
        Strength = strength;
        Health = health;

        FullHealth = Health;

        Ability = new Freeze();
        State = Effect.Normal;
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

}