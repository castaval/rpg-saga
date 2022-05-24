public class GameLogger : ILogger
{
    public void PrintStart()
    {
        Console.WriteLine("\nПриветствуем в Akvelon RPG SAGA!");
    }

    public void PrintTour(int numberTour)
    {
        Console.WriteLine($"Кон {numberTour}.\n");

    }

    public void PrintInfo()
    {

    }

    public void PrintAttack(IPlayer playerAttack, IPlayer playerDefend)
    {
        Console.WriteLine($"({playerAttack.ClassName}) {playerAttack.Name} наносит урон {playerAttack.Strength} противнику ({playerDefend.ClassName}) {playerDefend.Name}");
    }

    public void PrintUltimate(IPlayer playerAttack, IPlayer playerDefend, int randomUlt)
    {
        if (playerAttack.ClassName == "Маг")
        {
            Console.WriteLine($"({playerAttack.ClassName}) {playerAttack.Name} использует ({playerAttack.Ability[randomUlt].AbilityName}) на противника ({playerDefend.ClassName}) {playerDefend.Name}");
        }
        else if (playerAttack.ClassName == "Рыцарь")
        {
            Console.WriteLine($"({playerAttack.ClassName}) {playerAttack.Name} использует ({playerAttack.Ability[randomUlt].AbilityName}) и наносит урон {playerAttack.Strength} противнику ({playerDefend.ClassName}) {playerDefend.Name}");
        } else if (playerAttack.ClassName == "Лучник")
        {
            Console.WriteLine($"({playerAttack.ClassName}) {playerAttack.Name} использует ({playerAttack.Ability[randomUlt].AbilityName}) и поджигает противника ({playerDefend.ClassName}) {playerDefend.Name}");
        } else if (playerAttack.ClassName == "Огненный маг")
        {
            if (playerAttack.Ability[randomUlt].AbilityName == "Заворожение")
            {
                Console.WriteLine($"({playerAttack.ClassName}) {playerAttack.Name} использует ({playerAttack.Ability[randomUlt].AbilityName}) на противника ({playerDefend.ClassName}) {playerDefend.Name}");
            }
            else
            {
                Console.WriteLine($"({playerAttack.ClassName}) {playerAttack.Name} использует ({playerAttack.Ability[randomUlt].AbilityName}) и наносит урон {playerAttack.Strength} противнику ({playerDefend.ClassName}) {playerDefend.Name}");
            }
        }
        else if (playerAttack.ClassName == "Воин")
        {
            if (playerAttack.Ability[randomUlt].AbilityName == "Удар возмездия")
            {
                Console.WriteLine($"({playerAttack.ClassName}) {playerAttack.Name} использует ({playerAttack.Ability[randomUlt].AbilityName}) и наносит урон {playerAttack.Strength} противнику ({playerDefend.ClassName}) {playerDefend.Name}");
            }
            else
            {
                Console.WriteLine($"({playerAttack.ClassName}) {playerAttack.Name} использует ({playerAttack.Ability[randomUlt].AbilityName}) на противника ({playerDefend.ClassName}) {playerDefend.Name}");
            }
        }
        else if (playerAttack.ClassName == "Стрелок")
        {
            if (playerAttack.Ability[randomUlt].AbilityName == "Огненные стрелы")
            {
                Console.WriteLine($"({playerAttack.ClassName}) {playerAttack.Name} использует ({playerAttack.Ability[randomUlt].AbilityName}) и поджигает противника ({playerDefend.ClassName}) {playerDefend.Name}");
            }
            else
            {
                Console.WriteLine($"({playerAttack.ClassName}) {playerAttack.Name} использует ({playerAttack.Ability[randomUlt].AbilityName}) на противника ({playerDefend.ClassName}) {playerDefend.Name}");
            }
        }
    }

    public void PrintEffect(IPlayer player)
    {
        if (player.MyEffect is Stun)
        {
            Console.WriteLine($"({player.ClassName}) {player.Name} пропускает ход!");
        }

        if (player.MyEffect is LongDamage longDamage)
        {
            Console.WriteLine($"({player.ClassName}) {player.Name} получает урон {longDamage.Factor}");
        }
    }

    public void PrintDefeat(IPlayer loser)
    {
        Console.WriteLine($"({loser.ClassName}) {loser.Name} погибает! \n\n");
    }

    public void PrintEnd(IPlayer winner)
    {
        Console.WriteLine($"({winner.ClassName}) {winner.Name} побеждает! \nThe END...");
    }
}