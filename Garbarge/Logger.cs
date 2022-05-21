// namespace Logs
// {
//     using System;

//     public static class Logger
//     {   
//         private static int numberKone = 1;
//         public static void StartLog()
//         {
//             Console.WriteLine("\nПриветствуем в Akvelon RPG SAGA!");
//         }

//         public static void LogSelectNumber()
//         {
//             Console.WriteLine("Выберите число игроков:");
//         }

//         public static void LogChangeHero()
//         {
//             Console.WriteLine("Добавьте персонажей с новыми способностями!");
//         }

//         public static void LogSelectHero()
//         {
//             Console.WriteLine("\n1 - Огненный маг\n2 - Воин\n3 - Стрелок");
//         }

//         public static void LogStartGame()
//         {
//             Console.WriteLine("\nПриступить к выбору количества игроков? Да - Нет");
//         }

//         public static void LogAddAbility(int choiceClass)
//         {   
//             if (choiceClass == 1)
//             {
//                 Console.WriteLine("Фаербол - наносит 2 * сила урона");
//                 Console.WriteLine("Добавить? Да - Нет");
//             }
//             else if (choiceClass == 2)
//             {
//                 Console.WriteLine("Оглушающий удар - противник пропускает ход");
//                 Console.WriteLine("Добавить? Да - Нет");
//             }
//             else if (choiceClass == 3)
//             {
//                 Console.WriteLine("Ледяные стрелы - противник получает 5 урона за ход (можно применить один раз)");
//                 Console.WriteLine("Добавить? Да - Нет");
//             }
            
//         }

//         public static void LogKone()
//         {
//             Console.WriteLine($"Кон {numberKone}.\n");
//             numberKone += 1;
//         }

//         public static void LogVersus(IPlayer firstPlayer, IPlayer secondPlayer)
//         {
//             Console.WriteLine($"({firstPlayer.ClassName}) {firstPlayer.PlayerName} vs ({secondPlayer.ClassName}) {secondPlayer.PlayerName}");
//         }

//         public static void LogAttack(IPlayer firstPlayer, IPlayer secondPlayer)
//         {   
//             Console.WriteLine($"({firstPlayer.ClassName}) {firstPlayer.PlayerName} наносит урон {firstPlayer.Attack} противнику ({secondPlayer.ClassName}) {secondPlayer.PlayerName}");
//         }

//         public static void LogUltimate(IPlayer firstPlayer, IPlayer secondPlayer)
//         {
//             if (firstPlayer.ClassName == "Маг")
//             {
//                 Console.WriteLine($"({firstPlayer.ClassName}) {firstPlayer.PlayerName} использует ({firstPlayer.UltimateName}) на противника ({secondPlayer.ClassName}) {secondPlayer.PlayerName}");
//             } 
//             else if (firstPlayer.ClassName == "Рыцарь") 
//             {
//                 Console.WriteLine($"({firstPlayer.ClassName}) {firstPlayer.PlayerName} использует ({firstPlayer.UltimateName}) и наносит урон {firstPlayer.Attack} противнику ({secondPlayer.ClassName}) {secondPlayer.PlayerName}");
//             } else if (firstPlayer.ClassName == "Лучник")
//             {
//                 Console.WriteLine($"({firstPlayer.ClassName}) {firstPlayer.PlayerName} использует ({firstPlayer.UltimateName}) и поджигает противника ({secondPlayer.ClassName}) {secondPlayer.PlayerName}");
//             } else if (firstPlayer.ClassName == "Огненный маг")
//             {
//                 if (firstPlayer.UltimateName == "Заворожение")
//                 {
//                     Console.WriteLine($"({firstPlayer.ClassName}) {firstPlayer.PlayerName} использует ({firstPlayer.UltimateName}) на противника ({secondPlayer.ClassName}) {secondPlayer.PlayerName}");
//                 } 
//                 else
//                 {
//                     Console.WriteLine($"({firstPlayer.ClassName}) {firstPlayer.PlayerName} использует ({firstPlayer.UltimateName}) и наносит урон {firstPlayer.Attack} противнику ({secondPlayer.ClassName}) {secondPlayer.PlayerName}");
//                 }
//             }
//             else if (firstPlayer.ClassName == "Воин")
//             {
//                 if (firstPlayer.UltimateName == "Удар возмездия")
//                 {
//                     Console.WriteLine($"({firstPlayer.ClassName}) {firstPlayer.PlayerName} использует ({firstPlayer.UltimateName}) и наносит урон {firstPlayer.Attack} противнику ({secondPlayer.ClassName}) {secondPlayer.PlayerName}");
//                 }
//                 else
//                 {
//                     Console.WriteLine($"({firstPlayer.ClassName}) {firstPlayer.PlayerName} использует ({firstPlayer.UltimateName}) на противника ({secondPlayer.ClassName}) {secondPlayer.PlayerName}");
//                 }
//             }
//             else if (firstPlayer.ClassName == "Стрелок")
//             {
//                 if (firstPlayer.UltimateName == "Огненные стрелы")
//                 {
//                     Console.WriteLine($"({firstPlayer.ClassName}) {firstPlayer.PlayerName} использует ({firstPlayer.UltimateName}) и поджигает противника ({secondPlayer.ClassName}) {secondPlayer.PlayerName}");
//                 }
//                 else
//                 {
//                     Console.WriteLine($"({firstPlayer.ClassName}) {firstPlayer.PlayerName} использует ({firstPlayer.UltimateName}) на противника ({secondPlayer.ClassName}) {secondPlayer.PlayerName}");
//                 }
//             }
            
//         }

//         public static void LogSkip(IPlayer firstPlayer)
//         {
//             Console.WriteLine($"({firstPlayer.ClassName}) {firstPlayer.PlayerName} пропускает ход!");
//         }

//         public static void LogDeath(string classLooser, string nameLoser)
//         {
//             Console.WriteLine($"({classLooser}) {nameLoser} погибает! \n\n");
//         }

//         public static void LogLongDamage(IPlayer firstPlayer, bool firstSpell)
//         {   
//             if (firstSpell)
//             {
//                 Console.WriteLine($"({firstPlayer.ClassName}) {firstPlayer.PlayerName} горит и получает урон -2");
//             }
//             else
//             {
//                 Console.WriteLine($"({firstPlayer.ClassName}) {firstPlayer.PlayerName} леденеет и получает урон -5");
//             }
//         }

//         public static void LogWin(IPlayer winner)
//         {
//             Console.WriteLine($"({winner.ClassName}) {winner.PlayerName} побеждает! \nThe END...");
//         }

//     }
// }
