public class Archer : IPlayer
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Health { get; set; }
    public List <IAbility> Abilities { get; set; } = new List<IAbility>();
    public List <IEffect> MyEffects { get; set; } = new List<IEffect>();
    public IEffect NormalState { get; set; }
    public string ClassName { get; set; }

    public Archer(string name, int strength, int health, string className)
    {
        Name = name;
        Strength = strength;
        Health = health;

        ClassName = className;

        Abilities.Add(new FireArrows());
        NormalState = new Normal(Strength, Health);
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
        int randomUlt = random.Next(0, Abilities.Count);
        Abilities[randomUlt].Spell(myself, enemy, round);
        return randomUlt;
    }

    public void Effect(IPlayer myself)
    {
        if (MyEffects.Count != 0)
        {
            foreach (var effect in MyEffects)
            {
                effect.State(myself);
            }
        }
    }

    public void DeleteEffect(IPlayer myself, int round, int numberPlayer)
    {
        if (MyEffects.Count != 0)
        {
            foreach (var effect in MyEffects.ToList())
            {
                effect.DeleteState(myself, round, numberPlayer);
            }
        }
    }

    public void RestoreAfterBattle()
    {
        if (NormalState is Normal normal)
        {
            Health = normal.Health;
            Strength = normal.Strength;
        }
        MyEffects.Clear();
    }
}