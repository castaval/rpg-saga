// namespace Gaming
// {
//     using System;
//     using Logs;
//     using Fighting;

//     public class Game
//     {   
//         private int numberOfPlayers;
//         private int NumberOfPlayers
//         {
//             get { return numberOfPlayers; }

//             set 
//             {
//                 if (value % 2 == 0) {
//                     numberOfPlayers = value;
//                 } 
//                 else
//                 {
//                     Console.WriteLine("Введите четное число!");
//                 }
//             }
//         }

//         public void Run()
//         {   
//             List<Player> players = new List<Player>(Start());
//             Fight fight = new Fight(players);
            
//             while (true)
//             {   
//                 Logger.LogKone();
//                 fight.Draw();
//                 fight.Kone();
                
//                 if (fight.IsWin())
//                 {
//                     break;
//                 }
//             }

//             Logger.LogWin(fight.Winner);
//         }

//         private List<Player> Start()
//         {   
//             Logger.StartLog();

//             Logger.LogChangeHero();

//             string yesOrNot = "Нет";
//             bool newClassMage = false;
//             bool newClassKnight = false;
//             bool newClassArcher = false;

//             while (true)
//             {   
//                 Logger.LogSelectHero();

//                 int choice = Int32.Parse(Console.ReadLine());

//                 if (choice == 1)
//                 {   
//                     if (yesOrNot != "Да")
//                     {
//                         Logger.LogAddAbility(choice);
//                         yesOrNot = Console.ReadLine();

//                         if (yesOrNot == "Да")
//                         {
//                             newClassMage = true;
//                             yesOrNot = "Нет";
//                         }
//                         else
//                         {
//                             newClassMage = false;
//                         }
//                     }
                    
//                 } 
//                 else if (choice == 2)
//                 {
//                     if (yesOrNot != "Да")
//                     {
//                         Logger.LogAddAbility(choice);

//                         yesOrNot = Console.ReadLine();

//                         if (yesOrNot == "Да")
//                         {
//                             newClassKnight = true;
//                             yesOrNot = "Нет";

//                         }
//                         else
//                         {
//                             newClassKnight = false;
//                         }
//                     }
//                 }
//                 else if (choice == 3)
//                 {   
//                     if (yesOrNot != "Да")
//                     {
//                         Logger.LogAddAbility(choice);

//                         yesOrNot = Console.ReadLine();

//                         if (yesOrNot == "Да")
//                         {
//                             newClassArcher = true;
//                             yesOrNot = "Нет";
//                         }
//                         else
//                         {
//                             newClassArcher = false;
//                         }
//                     }   
//                 }

//                 Logger.LogStartGame();

//                 string answer = Console.ReadLine();
//                 if (answer == "Да")
//                 {
//                     break;
//                 }
//             }

//             Logger.LogSelectNumber();
            
//             NumberOfPlayers = Int32.Parse(Console.ReadLine());
            
//             while (numberOfPlayers == 0)
//             {
//                 NumberOfPlayers = Int32.Parse(Console.ReadLine());
//             }
     
//             List<Player> allPlayers = new List<Player>();

//             string[] NamesOfPlayers = {"Nikita", "Stanislav", "Oleg", "Danila", "Alexey", "Michael", "Max", "Ivan", "Nazar", "Kevin", "Vladislav"};

//             Random random = new Random();

//             int randomPlayer;
//             string randomPlayerName;
//             int randomPlayerStrength;
//             int randomPlayerHealth;

//             for (int i = 0; i < numberOfPlayers; i++)
//             {

//                 if ((newClassMage && !newClassArcher && !newClassKnight) || (newClassKnight && !newClassArcher && !newClassMage) || (newClassArcher && !newClassKnight && !newClassMage))
//                 {
//                     randomPlayer = random.Next(4);
//                 }
//                 else if ((newClassMage && newClassKnight && !newClassArcher) || (newClassMage && newClassArcher && !newClassKnight) || (newClassKnight && newClassArcher && !newClassMage))
//                 {
//                     randomPlayer = random.Next(5);
//                 }
//                 else if (newClassKnight && newClassArcher && newClassMage)
//                 {
//                     randomPlayer = random.Next(6);
//                 }
//                 else
//                 {
//                     randomPlayer = random.Next(3);
//                 }

//                 randomPlayerName = NamesOfPlayers[random.Next(11)];
//                 randomPlayerStrength = random.Next(10, 50);
//                 randomPlayerHealth = random.Next(50, 110);

//                 if (randomPlayer == 0)
//                 {
//                     allPlayers.Add(new Archer(randomPlayerName, randomPlayerStrength, randomPlayerHealth));
//                 } else if (randomPlayer == 1)
//                 {
//                     allPlayers.Add(new Knight(randomPlayerName, randomPlayerStrength, randomPlayerHealth));
//                 } else if (randomPlayer == 2)
//                 {
//                     allPlayers.Add(new Mage(randomPlayerName, randomPlayerStrength, randomPlayerHealth));
//                 } else if (randomPlayer == 3 && newClassMage && !newClassArcher && !newClassKnight)
//                 {
//                     Mage mage = new Mage(randomPlayerName, randomPlayerStrength, randomPlayerHealth);
//                     mage.ClassName = "Огненный маг";
//                     mage.AllSpells = true;
//                     allPlayers.Add(mage);
//                 }
//                 else if (randomPlayer == 3 && newClassKnight && !newClassArcher && !newClassMage)
//                 {
//                     Knight knight = new Knight(randomPlayerName, randomPlayerStrength, randomPlayerHealth);
//                     knight.ClassName = "Воин";
//                     knight.AllSpells = true;
//                     allPlayers.Add(knight);
//                 }
//                 else if (randomPlayer == 3 && newClassArcher && !newClassKnight && !newClassMage)
//                 {
//                     Archer archer = new Archer(randomPlayerName, randomPlayerStrength, randomPlayerHealth);
//                     archer.ClassName = "Стрелок";
//                     archer.AllSpells = true;
//                     allPlayers.Add(archer);
//                 }
//                 else if (randomPlayer == 3 && newClassMage && newClassKnight && !newClassArcher)
//                 {
//                     Mage mage = new Mage(randomPlayerName, randomPlayerStrength, randomPlayerHealth);
//                     mage.ClassName = "Огненный маг";
//                     mage.AllSpells = true;
//                     allPlayers.Add(mage);
//                 }
//                 else if (randomPlayer == 4 && newClassMage && newClassKnight && !newClassArcher)
//                 {
//                     Knight knight = new Knight(randomPlayerName, randomPlayerStrength, randomPlayerHealth);
//                     knight.ClassName = "Воин";
//                     knight.AllSpells = true;
//                     allPlayers.Add(knight);
//                 }
//                 else if (randomPlayer == 3 && newClassMage && newClassArcher && !newClassKnight)
//                 {
//                     Mage mage = new Mage(randomPlayerName, randomPlayerStrength, randomPlayerHealth);
//                     mage.ClassName = "Огненный маг";
//                     mage.AllSpells = true;
//                     allPlayers.Add(mage);
//                 }
//                 else if (randomPlayer == 4 && newClassMage && newClassArcher && !newClassKnight)
//                 {
//                     Archer archer = new Archer(randomPlayerName, randomPlayerStrength, randomPlayerHealth);
//                     archer.ClassName = "Стрелок";
//                     archer.AllSpells = true;
//                     allPlayers.Add(archer);
//                 }
//                 else if (randomPlayer == 3 && newClassKnight && newClassArcher && !newClassMage)
//                 {
//                     Knight knight = new Knight(randomPlayerName, randomPlayerStrength, randomPlayerHealth);
//                     knight.ClassName = "Воин";
//                     knight.AllSpells = true;
//                     allPlayers.Add(knight);
//                 }
//                 else if (randomPlayer == 4 && newClassKnight && newClassArcher && !newClassMage)
//                 {
//                     Archer archer = new Archer(randomPlayerName, randomPlayerStrength, randomPlayerHealth);
//                     archer.ClassName = "Стрелок";
//                     archer.AllSpells = true;
//                     allPlayers.Add(archer);
//                 } 
//                 else if (randomPlayer == 3 && newClassKnight && newClassArcher && newClassMage)
//                 {
//                     Mage mage = new Mage(randomPlayerName, randomPlayerStrength, randomPlayerHealth);
//                     mage.ClassName = "Огненный маг";
//                     mage.AllSpells = true;
//                     allPlayers.Add(mage);
//                 }
//                 else if (randomPlayer == 4 && newClassKnight && newClassArcher && newClassMage)
//                 {
//                     Knight knight = new Knight(randomPlayerName, randomPlayerStrength, randomPlayerHealth);
//                     knight.ClassName = "Воин";
//                     knight.AllSpells = true;
//                     allPlayers.Add(knight);
//                 }
//                 else if (randomPlayer == 5 && newClassKnight && newClassArcher && newClassMage)
//                 {
//                     Archer archer = new Archer(randomPlayerName, randomPlayerStrength, randomPlayerHealth);
//                     archer.ClassName = "Стрелок";
//                     archer.AllSpells = true;
//                     allPlayers.Add(archer);
//                 }

//             }

//             return allPlayers;

//         }

//     }
// }