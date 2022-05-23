public class Knight : IPlayer
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Health { get; set; }
    public IAbility Ability { get; set; }
    public IEffect MyEffect { get; set; } = null;
    public IEffect NormalState { get; set; }
    public string ClassName { get; set; }

    public Knight(string name, int strength, int health, string className)
    {
        Name = name;
        Strength = strength;
        Health = health;

        ClassName = className;

        Ability = new VengeanceStrike();
        NormalState = new Normal(Strength, Health);
    }

    public void Action(IPlayer myself, IPlayer enemy, int round)
    {
        Random rand = new Random();

        if (rand.Next(0, 2) > 0)
        {
            AttackEnemy(enemy);
        }
        else
        {
            Ultimate(myself, enemy, round);
        }
    }

    public void TakingDamage(int damage)
    {
        Health -= damage;
    }

    public void AttackEnemy(IPlayer enemy)
    {
        enemy.TakingDamage(Strength);
    }

    public void Ultimate(IPlayer myself, IPlayer enemy, int round)
    {
        Ability.Spell(myself, enemy, round);
    }

    public void Effect(IPlayer myself)
    {
        if (MyEffect != null)
        {
            MyEffect.State(myself);
        }
    }

    public void DeleteEffect(IPlayer myself, int round)
    {
        if (MyEffect != null)
        {
            MyEffect.DeleteState(myself, round);
        }
    }

    public void RestoreAfterBattle()
    {
        MyEffect = NormalState;
        if (NormalState is Normal normal)
        {
            Health = normal.Health;
            Strength = normal.Strength;
        }
    }

}