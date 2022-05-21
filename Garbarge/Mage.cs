// namespace Players
// {
//     public class Mage : Player 
//     {   
//         private string className = "Маг";

//         private string ultimateName = "Заворожение";

//         private static string classType = "Маг";

//         private bool allSpells;

//         public override string ClassType { get { return classType; } set { classType = value; } }
//         public override bool AllSpells { get { return allSpells; } set { allSpells = value; } }

//         public override string ClassName { get { return className; } set { className = value; } }

//         public override string UltimateName { get {return ultimateName; } set {ultimateName = value;} }


//         public Mage(string name, int strength, int health) : base(name, strength, health){}

//         private void Freeze()
//         {
//             ultimateIsUsed = true;
//         }

//         private void Fireball()
//         {
//             ultimateIsUsed = true;
//             strength = strength * 2;
//         }

//         public override void Ultimate(int random)
//         {  

//             if (allSpells == false)
//             {   
//                 Freeze();
//             } else
//             {
//                 if (random > 0)
//                 {   
//                     ultimateName = "Заворожение";
//                     Freeze();
//                 }
//                 else
//                 {   
//                     ultimateName = "Фаерболл";
//                     Fireball();
//                 }
//             }

            
//         }

//         public override void UltimateCooldown()
//         {   

//             if (ultimateName == "Фаерболл" && ultimateIsUsed == true)
//             {
//                 strength = strength / 2;
//             }
//             ultimateIsUsed = false;

            
//         }

//     }

// }