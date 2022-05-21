// namespace Players
// {
//     using System;
//     public abstract class Player 
//     {
//         protected string name { get; set; } 
//         protected int strength { get; set; }
//         protected int health { get; set; }

//         protected bool ultimateIsUsed { get; set; }

//         protected bool secondUltimateIsUsed { get; set; }

//         protected int fullHealth { get; set; }
//         public int Attack { get { return strength; } }

    
//         public string PlayerName {get { return name; } }

//         public abstract string ClassType { get; set; }

//         public abstract bool AllSpells { get; set; }

//         public abstract string ClassName { get; set; }
//         public abstract string UltimateName { get; set; }

//         public bool UltimateIsUsed {get {return ultimateIsUsed;} }
//         public bool SecondUltimateIsUsed {get {return secondUltimateIsUsed;} }

//         protected Player(string name, int strength, int health)
//         {
//             this.name = name;
//             this.strength = strength;
//             this.health = health;
//             fullHealth = this.health;
//             ultimateIsUsed = false;
//             secondUltimateIsUsed = false;
//         }

//         public bool SetDamage(int damage)
//         {
//             health -= damage;

//             if (health > 0)
//             {
//                 return false;
//             } else {
//                 return true;
//             }
//         }

//         public void HealHealthAfterBattle()
//         {
//             health = fullHealth;
//         }

//         public abstract void Ultimate(int random);
//         public abstract void UltimateCooldown();
//     }  
// }