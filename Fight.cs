namespace Fighting
{   
    using Players;
    using Gaming;
    using System;
    using Logs;

    public class Fight
    {   
        private List<Player> gamers;

        public Player Winner { get {return gamers[0];} }

        public Fight(List<Player> gamers)
        {
            this.gamers = gamers;
        }


        public void Draw()
        {
            Random random = new Random();
            for (int i = gamers.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                var temp = gamers[j];
                gamers[j] = gamers[i];
                gamers[i] = temp;
            }
        }

        public void Kone()
        {   
            for (int i = 0; i < gamers.Count; i++)
            {   
                if (i + 1 < gamers.Count)
                {
                    Battle(gamers[i], gamers[i+1]);
                } 
            }
        }

        private bool PlayerAttack(Player firstPlayer, Player secondPlayer)
        {
            bool Win = secondPlayer.SetDamage(firstPlayer.Attack);

            Logger.LogAttack(firstPlayer, secondPlayer);

            return Win;
        }

        private bool SleepUltimate(Player firstPlayer, Player secondPlayer, int random)
        {
            firstPlayer.Ultimate(random);

            Logger.LogUltimate(firstPlayer, secondPlayer);

            return false;
        }

        private bool DamageUltimate(Player firstPlayer, Player secondPlayer, int random)
        {
            firstPlayer.Ultimate(random);

            bool Win = secondPlayer.SetDamage(firstPlayer.Attack);

            Logger.LogUltimate(firstPlayer, secondPlayer);

            firstPlayer.UltimateCooldown();

            return Win;
        }

        private bool ArcherUltimate(Player firstPlayer, Player secondPlayer, int random)
        {   
            bool Win = false;

            if (random == 1)
            {
                firstPlayer.Ultimate(random);

                Logger.LogUltimate(firstPlayer, secondPlayer);
            }
            else 
            {
                if (firstPlayer.SecondUltimateIsUsed)
                {
                    Win = PlayerAttack(firstPlayer, secondPlayer);
                }
                else
                {
                    firstPlayer.Ultimate(random);

                    Logger.LogUltimate(firstPlayer, secondPlayer);
                }
            }

            return Win;
        }

        private bool FireMageUltimate(Player firstPlayer, Player secondPlayer, int random)
        {
            bool Win = false;

            if (random > 0)
            {
                Win = SleepUltimate(firstPlayer, secondPlayer, random);
            } 
            else 
            {
                
                Win = DamageUltimate(firstPlayer, secondPlayer, random);
            }  

            return Win;
        }

        private bool WarriorUltimate(Player firstPlayer, Player secondPlayer, int random)
        {
            bool Win = false;

            if (random > 0)
            {
                Win = DamageUltimate(firstPlayer, secondPlayer, random);

            } 
            else 
            {
                
                Win = SleepUltimate(firstPlayer, secondPlayer, random);

            }  

            return Win;
        }

        private void Battle(Player firstPlayer, Player secondPlayer)
        {   
            bool firstWin = false;
            bool secondWin = false;
            bool firstSpell = false;
            int round = 1;
            int ultFirstPlayer = 0;
            int ultSecondPlayer = 0;


            Random rand = new Random();
            
            Logger.LogVersus(firstPlayer, secondPlayer);

            while (true)
            {   
                if (round - ultFirstPlayer > 0 && ultFirstPlayer > 0 && (firstPlayer.ClassName == "Маг" || firstPlayer.ClassName == "Огненный маг" || firstPlayer.ClassName == "Воин"))
                {
                    firstPlayer.UltimateCooldown();
                }

                if (!secondPlayer.UltimateIsUsed)
                {   
                    if (!firstPlayer.UltimateIsUsed)
                    {
                        if (rand.Next(3) > 0)
                        {   
                            firstWin = PlayerAttack(firstPlayer, secondPlayer);
                        } 
                        else 
                        {   
                            ultFirstPlayer = round;

                            if (firstPlayer.ClassName == "Маг")
                            {     
                                firstWin = SleepUltimate(firstPlayer, secondPlayer, 1);
                            } 
                            else if (firstPlayer.ClassName == "Рыцарь") 
                            {
                                firstWin = DamageUltimate(firstPlayer, secondPlayer, 1);

                            } else if (firstPlayer.ClassName == "Лучник")
                            {
                                ArcherUltimate(firstPlayer, secondPlayer, 1);
                            } 
                            else if (firstPlayer.ClassName != "Маг" && firstPlayer.ClassType == "Маг")
                            {
                                int random = rand.Next(2);

                                firstWin = FireMageUltimate(firstPlayer, secondPlayer, random);
                            }
                            else if (firstPlayer.ClassName != "Рыцарь" && firstPlayer.ClassType == "Рыцарь")
                            {
                                int random = rand.Next(2);

                                firstWin = WarriorUltimate(firstPlayer, secondPlayer, random);

                            }
                            else if (firstPlayer.ClassName != "Лучник" && firstPlayer.ClassType == "Лучник")
                            {
                                int random = rand.Next(2);

                                firstWin = ArcherUltimate(firstPlayer, secondPlayer, random);    
                            }
                        }
                    } 
                    else 
                    {
                        firstWin = PlayerAttack(firstPlayer, secondPlayer);
                    }
                } 
                else 
                {
                    if (secondPlayer.ClassName == "Маг" || secondPlayer.ClassName == "Огненный маг" || secondPlayer.ClassName == "Воин")
                    {
                        firstWin = secondPlayer.SetDamage(0);

                        Logger.LogSkip(firstPlayer);
                    } 
                    else if (secondPlayer.ClassName == "Лучник")
                    {
                        if (!firstPlayer.UltimateIsUsed)
                        {
                            if (rand.Next(3) > 0)
                            {
                                firstWin = PlayerAttack(firstPlayer, secondPlayer);
                            } 
                            else 
                            {   
                                ultFirstPlayer = round;

                                if (firstPlayer.ClassName == "Маг")
                                {     
                                    firstWin = SleepUltimate(firstPlayer, secondPlayer, 1);
                                } 
                                else if (firstPlayer.ClassName == "Рыцарь") 
                                {
                                    firstWin = DamageUltimate(firstPlayer, secondPlayer, 1);

                                } 
                                else if (firstPlayer.ClassName == "Лучник")
                                {
                                    ArcherUltimate(firstPlayer, secondPlayer, 1);
                                }
                                else if (firstPlayer.ClassName != "Маг" && firstPlayer.ClassType == "Маг")
                                {
                                    int random = rand.Next(2);
                                    
                                    firstWin = FireMageUltimate(firstPlayer, secondPlayer, random);

                                }
                                else if (firstPlayer.ClassName != "Рыцарь" && firstPlayer.ClassType == "Рыцарь")
                                {
                                    int random = rand.Next(2);

                                    firstWin = WarriorUltimate(firstPlayer, secondPlayer, random);
 
                                }
                                else if (firstPlayer.ClassName != "Лучник" && firstPlayer.ClassType == "Лучник")
                                {
                                    int random = rand.Next(2);

                                    firstWin = ArcherUltimate(firstPlayer, secondPlayer, random);         
                                }
                            }
                        } 
                        else 
                        {
                            firstWin = PlayerAttack(firstPlayer, secondPlayer);
                        }

                        firstWin = firstPlayer.SetDamage(2);

                        firstSpell = true;

                        Logger.LogLongDamage(firstPlayer, firstSpell);
                    }
                    else if (secondPlayer.ClassName == "Стрелок")
                    {
                        if (!firstPlayer.UltimateIsUsed)
                        {
                            if (rand.Next(3) > 0)
                            {
                                firstWin = PlayerAttack(firstPlayer, secondPlayer);
                            } 
                            else 
                            {   
                                ultFirstPlayer = round;

                                if (firstPlayer.ClassName == "Маг")
                                {     
                                    firstWin = SleepUltimate(firstPlayer, secondPlayer, 1);
                                } 
                                else if (firstPlayer.ClassName == "Рыцарь") 
                                {
                                    firstWin = DamageUltimate(firstPlayer, secondPlayer, 1);
                                } 
                                else if (firstPlayer.ClassName == "Лучник")
                                {
                                    ArcherUltimate(firstPlayer, secondPlayer, 1);
                                }
                                else if (firstPlayer.ClassName != "Маг" && firstPlayer.ClassType == "Маг")
                                {
                                    int random = rand.Next(2);

                                    firstWin = FireMageUltimate(firstPlayer, secondPlayer, random);

                                }
                                else if (firstPlayer.ClassName != "Рыцарь" && firstPlayer.ClassType == "Рыцарь")
                                {
                                    int random = rand.Next(2);

                                    firstWin = WarriorUltimate(firstPlayer, secondPlayer, random);

                                }
                                else if (firstPlayer.ClassName != "Лучник" && firstPlayer.ClassType == "Лучник")
                                {
                                    int random = rand.Next(2);

                                    firstWin = ArcherUltimate(firstPlayer, secondPlayer, random);    
                                }
                            }
                        } 
                        else 
                        {
                            firstWin = PlayerAttack(firstPlayer, secondPlayer);    
                        }

                        secondWin = firstPlayer.SetDamage(2);

                        firstSpell = true;

                        Logger.LogLongDamage(firstPlayer, firstSpell);
                    }
                    
                }

                if (secondPlayer.ClassName == "Стрелок" && secondPlayer.SecondUltimateIsUsed)
                {
                    secondWin = firstPlayer.SetDamage(5);

                    firstSpell = false;

                    Logger.LogLongDamage(firstPlayer, firstSpell);
                }


                if (firstWin)
                {
                    Logger.LogDeath(secondPlayer.ClassName, secondPlayer.PlayerName);
                    gamers.Remove(secondPlayer);
                    firstPlayer.HealHealthAfterBattle();
                    firstPlayer.UltimateCooldown();
                    break;
                }

                if (round - ultSecondPlayer > 0 && ultSecondPlayer > 0 && (secondPlayer.ClassName == "Маг" || secondPlayer.ClassName == "Огненный маг" || secondPlayer.ClassName == "Воин"))
                {
                    secondPlayer.UltimateCooldown();
                }

                if (!firstPlayer.UltimateIsUsed)
                {
                    if (!secondPlayer.UltimateIsUsed)
                    {
                        if (rand.Next(3) > 0)
                        {
                            secondWin = PlayerAttack(secondPlayer, firstPlayer);
                        } 
                        else 
                        {   
                            ultSecondPlayer = round;

                            if (secondPlayer.ClassName == "Маг")
                            {                                
                                secondWin = SleepUltimate(secondPlayer, firstPlayer, 1);

                            } 
                            else if (secondPlayer.ClassName == "Рыцарь") 
                            {
                                secondWin = DamageUltimate(secondPlayer, firstPlayer, 1);
                            }
                            else if (secondPlayer.ClassName == "Лучник")
                            {
                                ArcherUltimate(secondPlayer, firstPlayer, 1);
                            } 
                            else if (secondPlayer.ClassName != "Маг" && secondPlayer.ClassType == "Маг")
                            {
                                int random = rand.Next(2);

                                secondWin = FireMageUltimate(secondPlayer, firstPlayer, random);

                            }
                            else if (secondPlayer.ClassName != "Рыцарь" && secondPlayer.ClassType == "Рыцарь")
                            {
                                int random = rand.Next(2);

                                secondWin = WarriorUltimate(secondPlayer, firstPlayer, random);

                            }
                            else if (secondPlayer.ClassName != "Лучник" && secondPlayer.ClassType == "Лучник")
                            {
                                int random = rand.Next(2);
   
                                secondWin = ArcherUltimate(secondPlayer, firstPlayer, random);    
                            }
                        }  
                    }
                    else 
                    {
                        secondWin = PlayerAttack(secondPlayer, firstPlayer);
                    }
                } 
                else 
                {
                    if (firstPlayer.ClassName == "Маг" || firstPlayer.ClassName == "Огненный маг" || firstPlayer.ClassName == "Воин")
                    {
                        secondWin = firstPlayer.SetDamage(0);

                        Logger.LogSkip(secondPlayer);
                    }
                    else if (firstPlayer.ClassName == "Лучник")
                    {
                        if (!secondPlayer.UltimateIsUsed)
                        {
                            if (rand.Next(3) > 0)
                            {
                                secondWin = PlayerAttack(secondPlayer, firstPlayer);
                            } 
                            else 
                            {   
                                ultSecondPlayer = round;

                                if (secondPlayer.ClassName == "Маг")
                                {                                
                                    secondWin = SleepUltimate(secondPlayer, firstPlayer, 1);

                                } 
                                else if (secondPlayer.ClassName == "Рыцарь") 
                                {
                                    secondWin = DamageUltimate(secondPlayer, firstPlayer, 1);

                                }
                                else if (secondPlayer.ClassName == "Лучник")
                                {
                                    ArcherUltimate(secondPlayer, firstPlayer, 1);
                                }
                                else if (secondPlayer.ClassName != "Маг" && secondPlayer.ClassType == "Маг")
                                {
                                    int random = rand.Next(2);

                                    secondWin = FireMageUltimate(secondPlayer, firstPlayer, random);

                                }
                                else if (secondPlayer.ClassName != "Рыцарь" && secondPlayer.ClassType == "Рыцарь")
                                {
                                    int random = rand.Next(2);

                                    secondWin = WarriorUltimate(secondPlayer, firstPlayer, random);

                                }
                                else if (secondPlayer.ClassName != "Лучник" && secondPlayer.ClassType == "Лучник")
                                {
                                    int random = rand.Next(2);

                                    secondWin = ArcherUltimate(secondPlayer, firstPlayer, random);    
                                }
                            } 
                        }
                        else 
                        {
                            secondWin = PlayerAttack(secondPlayer, firstPlayer);
                        }

                        secondWin = secondPlayer.SetDamage(2);

                        firstSpell = true;

                        Logger.LogLongDamage(secondPlayer, firstSpell);  
                    }
                    else if (firstPlayer.ClassName == "Стрелок")
                    {
                        if (!secondPlayer.UltimateIsUsed)
                        {
                            if (rand.Next(3) > 0)
                            {
                                secondWin = PlayerAttack(secondPlayer, firstPlayer);
                            } 
                            else 
                            {   
                                ultSecondPlayer = round;

                                if (secondPlayer.ClassName == "Маг")
                                {                                
                                    secondWin = SleepUltimate(secondPlayer, firstPlayer, 1);
                                } 
                                else if (secondPlayer.ClassName == "Рыцарь") 
                                {
                                    secondWin = DamageUltimate(secondPlayer, firstPlayer, 1);
                                }
                                else if (secondPlayer.ClassName == "Лучник")
                                {
                                    ArcherUltimate(secondPlayer, firstPlayer, 1);
                                }
                                else if (secondPlayer.ClassName != "Маг" && secondPlayer.ClassType == "Маг")
                                {
                                    int random = rand.Next(2);

                                    secondWin = FireMageUltimate(secondPlayer, firstPlayer, random);

                                }
                                else if (secondPlayer.ClassName != "Рыцарь" && secondPlayer.ClassType == "Рыцарь")
                                {
                                    int random = rand.Next(2);

                                    secondWin = WarriorUltimate(secondPlayer, firstPlayer, random);
 
                                }
                                else if (secondPlayer.ClassName != "Лучник" && secondPlayer.ClassType == "Лучник")
                                {
                                    int random = rand.Next(2);

                                    secondWin = ArcherUltimate(secondPlayer, firstPlayer, random);    
                                }
                            } 
                        }
                        else 
                        {
                            secondWin = PlayerAttack(secondPlayer, firstPlayer);
                        }

                        secondWin = secondPlayer.SetDamage(2);

                        firstSpell = true;

                        Logger.LogLongDamage(secondPlayer, firstSpell);  
                    }
                }

                if (firstPlayer.ClassName == "Стрелок" && firstPlayer.SecondUltimateIsUsed)
                {
                    firstWin = secondPlayer.SetDamage(5);

                    firstSpell = false;

                    Logger.LogLongDamage(secondPlayer, firstSpell);
                }

                if (secondWin)
                {   
                    Logger.LogDeath(firstPlayer.ClassName, firstPlayer.PlayerName);
                    gamers.Remove(firstPlayer);
                    secondPlayer.HealHealthAfterBattle();
                    secondPlayer.UltimateCooldown();
                    break;
                }

                round++;
            }
        }

        public bool IsWin()
        {
            if (gamers.Count == 1)
            {
                return true;
            } else 
            {
                return false;
            }
        }
    }
}