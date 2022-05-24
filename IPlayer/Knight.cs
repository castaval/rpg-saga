public class Knight : IPlayer
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Health { get; set; }
    public List <IAbility> Ability { get; set; } = new List<IAbility>();
    public IEffect MyEffect { get; set; } = null;
    public IEffect NormalState { get; set; }
    public string ClassName { get; set; }

    public Knight(string name, int strength, int health, string className)
    {
        Name = name;
        Strength = strength;
        Health = health;

        ClassName = className;

        Ability.Add(new VengeanceStrike());
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

    public int Ultimate(IPlayer myself, IPlayer enemy, int round)
    {
        Random random = new Random();
        int randomUlt = random.Next(0, Ability.Count);
        Ability[randomUlt].Spell(myself, enemy, round);
        return randomUlt;
    }

    public void Effect(IPlayer myself)
    {
        if (MyEffect != null)
        {
            MyEffect.State(myself);
        }
    }

    public void DeleteEffect(IPlayer myself, int round, int numberPlayer)
    {
        if (MyEffect != null)
        {
            MyEffect.DeleteState(myself, round, numberPlayer);
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