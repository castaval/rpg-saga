// namespace Players 
// {
//     public class Knight : IPlayer 
//     {   
//         private string className = "Рыцарь";
//         private string ultimateName = "Удар возмездия";

//         private static string classType = "Рыцарь";

//         private bool allSpells;

//         public override string ClassType { get { return classType; } set { classType = value; } }
//         public override bool AllSpells { get { return allSpells; } set { allSpells = value; } }
//         public override string ClassName { get { return className; } set { className = value; } }

//         public override string UltimateName { get {return ultimateName; } set {ultimateName = value;} }


//         public Knight(string name, int strength, int health) : base(name, strength, health){}

//         private void PowerKick()
//         {
//             ultimateIsUsed = true;
//             strength = strength * 130 / 100;
//         }

//         private void ConcussionBlow()
//         {
//             ultimateIsUsed = true;
//         }
       
//         public override void Ultimate(int random)
//         {   
//             if (allSpells == false)
//             {   
//                 PowerKick();
//             } else
//             {
//                 if (random > 0)
//                 {   
//                     ultimateName = "Удар возмездия";
//                     PowerKick();
//                 }
//                 else
//                 {   
//                     ultimateName = "Оглушающий удар";
//                     ConcussionBlow();
//                 }
//             }

//         }

//         public override void UltimateCooldown()
//         {
//             if (ultimateName == "Удар возмездия" && ultimateIsUsed == true)
//             {
//                 strength = strength * 100 / 130;
//             }
//             ultimateIsUsed = false;
//         }
//     }

// }