using Characters;

namespace Arenas
{
    public class Arena
    {
        public static int robotWins;
        public static int playerWins;

        public bool isHPZeroOrLess(ICharacter character)
        {
            if (character.CurrentHP <= 0)
                return true;
            return false;
        }

        public void isCurrentHpGTthanMaxHP(ref ICharacter character)
        {
            if (character.CurrentHP > character.MaxHP)
            {
                character.CurrentHP = character.MaxHP;
            }
        }
        public double DamageDealt(ref ICharacter character, ref ICharacter opponent)
        {
            double randomDamage = GetRandomNumbers(-1, 1);
            return ((character.AttackDamage * 10) / (opponent.Armor + 10)) + randomDamage;
        }
       
        public double GetRandomNumbers(double min, double max)
        {
            Random random = new Random();
            return random.NextDouble() * (max - min) + min;
        }
       
        public void Fight(ICharacter playerCharacter, string? playerName, ICharacter robotCharacter)
        {
            string robotName = "Cici";
            Random random = new Random((int)(DateTime.Now.Ticks));

            int numberToStartTurn = random.Next(1, 3);
            if (numberToStartTurn == 1)
                Console.WriteLine($"First Turn: {playerName}");
            else
                Console.WriteLine($"First Turn: {robotName}");

            int stepForPLayerLevelingUp = 0;
            int stepForRobotLevelingUp = 0;
            double totalDamageDealtByPlayer = 0;
            double totalDamageDealtByRobot = 0;
            int turns = 1;
            while (isHPZeroOrLess( playerCharacter) == false && isHPZeroOrLess( robotCharacter) == false)
            {
                double copieRobotCurrentHP = robotCharacter.CurrentHP;
                double copiePlayerCurrentHP = playerCharacter.CurrentHP;

                double extraDamage = 0;
                switch (numberToStartTurn)
                {
                    case 1:
                        // player hit first   hit 1
                        robotCharacter.CurrentHP -= DamageDealt(ref playerCharacter, ref robotCharacter);
                        GetPassivesAndCounters(ref playerCharacter, robotCharacter.Type, ref extraDamage);
                        PrintConsoleMessages(playerName, copieRobotCurrentHP, robotCharacter, extraDamage);
                        ResetPassives(ref playerCharacter, ref extraDamage);
                        CalculateTotalDamage(ref totalDamageDealtByPlayer, copieRobotCurrentHP, robotCharacter, extraDamage);
                        LevelUp(ref playerCharacter, ref stepForPLayerLevelingUp, totalDamageDealtByPlayer, playerName);
                        if (isHPZeroOrLess( robotCharacter) == true)
                            break;
                        Console.WriteLine();

                        //robot turn          hit 2
                        playerCharacter.CurrentHP -= DamageDealt(ref robotCharacter, ref playerCharacter);
                        GetPassivesAndCounters(ref robotCharacter, playerCharacter.Type, ref extraDamage);
                        PrintConsoleMessages(robotName, copiePlayerCurrentHP, playerCharacter, extraDamage);
                        ResetPassives(ref robotCharacter, ref extraDamage);
                        CalculateTotalDamage(ref totalDamageDealtByRobot, copiePlayerCurrentHP, playerCharacter, extraDamage);
                        LevelUp(ref robotCharacter, ref stepForRobotLevelingUp, totalDamageDealtByRobot, robotName);
                        if (isHPZeroOrLess( playerCharacter) == true)
                            break;
                        Console.WriteLine();
                        break;

                    case 2:
                        // robot hit first    hit 1
                        playerCharacter.CurrentHP -= DamageDealt(ref robotCharacter, ref playerCharacter);
                        GetPassivesAndCounters(ref robotCharacter, playerCharacter.Type, ref extraDamage);
                        PrintConsoleMessages(robotName, copiePlayerCurrentHP, playerCharacter, extraDamage);
                        ResetPassives(ref robotCharacter, ref extraDamage);
                        CalculateTotalDamage(ref totalDamageDealtByRobot, copiePlayerCurrentHP, playerCharacter, extraDamage);
                        LevelUp(ref robotCharacter, ref stepForRobotLevelingUp, totalDamageDealtByRobot, robotName);
                        if (isHPZeroOrLess( playerCharacter) == true)
                            break;
                        Console.WriteLine();

                        // player turn        hit 2
                        totalDamageDealtByRobot = totalDamageDealtByRobot + copiePlayerCurrentHP - playerCharacter.CurrentHP + extraDamage;
                        robotCharacter.CurrentHP -= DamageDealt(ref playerCharacter, ref robotCharacter);
                        GetPassivesAndCounters(ref playerCharacter, robotCharacter.Type, ref extraDamage);
                        PrintConsoleMessages(playerName, copieRobotCurrentHP, robotCharacter, extraDamage);
                        ResetPassives(ref playerCharacter, ref extraDamage);
                        CalculateTotalDamage(ref totalDamageDealtByPlayer, copieRobotCurrentHP, robotCharacter, extraDamage);
                        LevelUp(ref playerCharacter, ref stepForPLayerLevelingUp, totalDamageDealtByPlayer, playerName);
                        if (isHPZeroOrLess( robotCharacter) == true)
                            break;
                        Console.WriteLine();
                        break;
                }

                turns++;
            }
            if (playerCharacter.CurrentHP <= 0)
            {
                Console.WriteLine($"Sorry {playerName}, you lost the duel");
                robotWins++;
            }
            else if (robotCharacter.CurrentHP <= 0)
            {
                Console.WriteLine($"congratulation {playerName}, you won!");
                playerWins++;
            }
            else
            {
                Console.WriteLine("DRAW");
            }

        }
        public void CalculateTotalDamage(ref double totalDamage, double opponentCurrentHp, ICharacter opponentCharacter, double damage)
        {
            totalDamage = totalDamage + opponentCurrentHp - opponentCharacter.CurrentHP + damage;
        }
        public void PrintConsoleMessages(string? name, double opponentCurrentHp, ICharacter opponentCharacter, double damage)
        {
            if (damage != 0)
                Console.WriteLine($"{name} dealt {(opponentCurrentHp - opponentCharacter.CurrentHP):N2} + {damage}  extra damage");
            else
                Console.WriteLine($"{name} dealt {(opponentCurrentHp - opponentCharacter.CurrentHP):N2}");
        }
        public void LevelUp(ref ICharacter character, ref int stepForLevelingUp, double totalDamage, string? Name)
        {
            if (totalDamage % 30 < 30 && totalDamage > 30 + stepForLevelingUp)
            {
                stepForLevelingUp += 50;
                character.CurrentHP = character.CurrentHP + 0.1 * character.MaxHP;
                character.AttackDamage *= 1.2;
                character.Armor *= 1.2;
                character.Passive *= 1.2;
                Console.WriteLine($"{Name} has leveled up!");
            }
        }
        public void GetPassivesAndCounters(ref ICharacter character, string oponentCharacterType, ref double extraDamage)
        {
            switch (character.Type)
            {
                case "archer":
                    isCurrentHpGTthanMaxHP(ref character);
                    Random zeroOrOne = new Random();
                    character.Passive = zeroOrOne.Next(1, 3);
                    if (character.Passive == 1)
                    {
                        character.AttackDamage += 2;
                    }
                    if (oponentCharacterType == "assasin")
                    {
                        character.CurrentHP -= 3; //assasin counters archer
                        character.Armor = 17;
                    } 
                    if (oponentCharacterType == "warrior")
                    {
                        extraDamage = 3;
                    }

                    break;
                case "assasin":
                    isCurrentHpGTthanMaxHP(ref character);
                    Random random = new Random();
                    int lucky = random.Next(0, 11);

                    if (lucky == 7)
                    {
                        character.AttackDamage += character.Passive;
                    }
                    if (oponentCharacterType == "warrior")
                    {
                        character.CurrentHP -= 2; // warrior counters assasin
                        character.AttackDamage = 25;
                        character.Armor = 7;
                    }
                    if (oponentCharacterType == "healer" || oponentCharacterType == "archer")
                    {
                        extraDamage = 3;
                    }
                    break;
                case "healer":
                    isCurrentHpGTthanMaxHP(ref character);

                    character.CurrentHP += character.Passive;
                    Console.WriteLine($"Healer healed {character.Passive} HP");

                    if (oponentCharacterType == "assasin")
                    {
                        character.CurrentHP -= 3; // assasin counters healer
                        character.Armor = 6;
                        character.Passive = 10.5;
                        character.AttackDamage = 10.2;
                    } 
                    if (oponentCharacterType == "archer")
                    {
                        character.Armor = 6;
                        character.Passive = 7;
                    }
                    if (oponentCharacterType == "warrior")
                    {
                        character.AttackDamage = 6.5;
                        character.Passive = 5.9;
                    }                    
                    if (oponentCharacterType == "mage")
                    {
                        extraDamage = 2;
                    }

                    break;
                case "mage":
                    isCurrentHpGTthanMaxHP(ref character);
                    character.AttackDamage += character.Passive;
                    if (oponentCharacterType == "healer")
                    {
                        character.CurrentHP -= 2; // healer counter mage
                        character.AttackDamage = 14;
                        character.Armor = 7;
                    }
                    if (oponentCharacterType == "assasin")
                    {
                        character.Armor = 9;
                    }
                    if (oponentCharacterType == "archer")
                    {
                        character.AttackDamage = 12;
                    }
                    break;
                case "warrior":
                    isCurrentHpGTthanMaxHP(ref character);
                    character.Armor += character.Passive;
                    if (oponentCharacterType == "archer")
                    {
                        character.CurrentHP -= 3; // archer counters warrior
                    }                 
                    if (oponentCharacterType == "assasin")
                    {
                        extraDamage = 2;
                    }
                    break;
            }
        }
        public ICharacter RobotChoise()
        {
            Random random = new Random((int)(DateTime.Now.Ticks));
            int number = random.Next(1, 6);
            switch (number)
            {
                case 1:
                    ICharacter warrior = new Warrior();
                    Console.WriteLine($"Robot chose Warrior!");
                    return warrior;
                case 2:
                    ICharacter archer = new Archer();
                    Console.WriteLine($"Robot chose Archer! ");
                    return archer;
                case 3:
                    ICharacter healer = new Healer();
                    Console.WriteLine($"Robot chose Healer! ");
                    return healer;
                case 4:
                    ICharacter mage = new Mage();
                    Console.WriteLine($"Robot chose Mage! ");
                    return mage;
                case 5:
                    ICharacter assasin = new Assasin();
                    Console.WriteLine($"Robot chose Assasin! ");
                    return assasin;
            }
            ICharacter character = new Warrior();
            return character;
        }
        public void ResetPassives(ref ICharacter character, ref double extraDamage)
        {
            extraDamage = 0;
            switch (character.Type)
            {
                case "archer":

                    break;
                case "assasin":
                    if (character.AttackDamage >= 40)
                    {
                        character.AttackDamage -= character.Passive;
                    }
                    break;
                case "healer":

                    break;
                case "mage":

                    break;
                case "warrior":

                    break;
            }
        }
    }
}