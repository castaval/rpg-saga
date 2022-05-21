// namespace Players 
// {
//     public class Archer : Player 
//     {   
//         private string className = "Лучник";
//         private string ultimateName = "Огненные стрелы";

//         private static string classType = "Лучник";

//         private bool allSpells;


//         public override string ClassType { get { return classType; } set { classType = value; } }
//         public override bool AllSpells { get { return allSpells; } set { allSpells = value; } }


//         public override string ClassName { get { return className; } set {className = value; } }
//         public override string UltimateName { get {return ultimateName; } set {ultimateName = value;} }

//         public Archer(string name, int strength, int health) : base(name, strength, health){}

//         private void FireArrows()
//         {
//             ultimateIsUsed = true;
//         }

//         private void IceArrows()
//         {
//             if (secondUltimateIsUsed == false)
//             {
//                 secondUltimateIsUsed = true;
//             }
//         }

//         public override void Ultimate(int random)
//         {
//             if (allSpells == false)
//             {   
//                 FireArrows();
//             } else
//             {
//                 if (random > 0)
//                 {   
//                     ultimateName = "Огненные стрелы";
//                     FireArrows();
//                 }
//                 else
//                 {   
//                     ultimateName = "Ледяные стрелы";
//                     IceArrows();
//                 }
//             }
//         }

//         public override void UltimateCooldown()
//         {
//             ultimateIsUsed = false;

//             secondUltimateIsUsed = false;
//         }
//     }

// }