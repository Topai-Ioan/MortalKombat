using Characters;
using System.ComponentModel;

namespace Arenas
{
    public class Arena
    {
        public static int robotWins;
        public static int playerWins;

        // TODO RANDOM MESSAGES WHEN GETTING DAMAGE
        /*public enum RandomMessages : int
        {
            [Description("Our destination is quickly approaching.")]
            message = 1,
            [Description("Albert Einstein was kind of smart.")]
            message2 = 2,
            [Description("That's the big question, isn't it?")]
            message3 = 3,
        }*/
        public void Fight(Character playerCharacter, string? playerName, Character robotCharacter)
        {
            string robotName = "Cici";
            Random random = new Random((int)(DateTime.Now.Ticks));

            int numberToStartTurn = random.Next(1, 3);
            if (numberToStartTurn == 1)
                Console.WriteLine($"First Turn: {playerName}");
            else
                Console.WriteLine($"First Turn: {robotName}");
            Console.WriteLine();

            int stepForPLayerLevelingUp = 0;
            int stepForRobotLevelingUp = 0;
            double totalDamageDealtByPlayer = 0;
            double totalDamageDealtByRobot = 0;
            int turns = 1;
            while (playerCharacter.isHPZeroOrLess() == false && robotCharacter.isHPZeroOrLess() == false)
            {
                double copieRobotCurrentHP = robotCharacter.CurrentHP;
                double copiePlayerCurrentHP = playerCharacter.CurrentHP;

                double extraDamage = 0;
                if (numberToStartTurn == 1)
                {
                    // player hit first 
                    CharacterTurn(playerCharacter, robotCharacter, extraDamage, playerName, copieRobotCurrentHP,
                        totalDamageDealtByPlayer, stepForPLayerLevelingUp);
                    if (robotCharacter.isHPZeroOrLess() == true)
                        break;
                    Console.WriteLine();

                    //robot turn        
                    CharacterTurn(robotCharacter, playerCharacter, extraDamage, robotName, copiePlayerCurrentHP,
                        totalDamageDealtByRobot, stepForRobotLevelingUp);
                    if (playerCharacter.isHPZeroOrLess() == true)
                        break;
                    Console.WriteLine();
                }
                else
                {
                    // robot hit first    
                    CharacterTurn(robotCharacter, playerCharacter, extraDamage, robotName, copiePlayerCurrentHP,
                        totalDamageDealtByRobot, stepForRobotLevelingUp);
                    if (playerCharacter.isHPZeroOrLess() == true)
                        break;
                    Console.WriteLine();

                    // player turn        
                    CharacterTurn(playerCharacter, robotCharacter, extraDamage, playerName, copieRobotCurrentHP,
                        totalDamageDealtByPlayer, stepForPLayerLevelingUp);
                    if (robotCharacter.isHPZeroOrLess() == true)
                        break;
                    Console.WriteLine();
                }

                turns++;
            }
            if (playerCharacter.isHPZeroOrLess() == true)
            {
                Console.WriteLine($"Sorry {playerName}, you lost the duel");
                robotWins++;
            }
            else if (robotCharacter.isHPZeroOrLess() == true)
            {
                Console.WriteLine($"congratulation {playerName}, you won!");
                playerWins++;
            }
            else
            {
                Console.WriteLine("DRAW");
            }

        }
        public void CharacterTurn(Character character, Character opponent, double extraDamage, string? name, double opponentCurentHP, double totalDamage, int step)
        {
            character.GetPassivesAndCounters(opponent.Type, ref extraDamage);
            character.Hit(opponent);
            PrintConsoleMessages(name, opponentCurentHP, opponent, extraDamage);
            character.ResetPassive();
            extraDamage = 0;

            CalculateTotalDamage(ref totalDamage, opponentCurentHP, opponent, extraDamage);
            character.TryToLevelUp(ref step, totalDamage, name);

            Console.WriteLine();
        }
        public void CalculateTotalDamage(ref double totalDamage, double opponentCurrentHp, Character opponentCharacter, double damage)
        {
            totalDamage = totalDamage + opponentCurrentHp - opponentCharacter.CurrentHP + damage;
        }
        public void PrintConsoleMessages(string? name, double opponentCurrentHp, Character opponentCharacter, double damage)
        {
            Random random = new Random((int)(DateTime.Now.Ticks));
            int messageNumber = random.Next(1, 11);

            if (damage != 0)
            {
                Console.WriteLine($"{name} dealt {(opponentCurrentHp - opponentCharacter.CurrentHP):N2} + {damage}  extra damage");
            }
            else
            {
                Console.WriteLine($"{name} dealt {(opponentCurrentHp - opponentCharacter.CurrentHP):N2}");
            }
        }
        public Character RobotChoise()
        {
            Random random = new Random((int)(DateTime.Now.Ticks));
            int number = random.Next(1, 6);
            switch (number)
            {
                case 1:
                    Character warrior = new Warrior();
                    Console.WriteLine($"Robot chose Warrior!");
                    return warrior;
                case 2:
                    Character archer = new Archer();
                    Console.WriteLine($"Robot chose Archer! ");
                    return archer;
                case 3:
                    Character healer = new Healer();
                    Console.WriteLine($"Robot chose Healer! ");
                    return healer;
                case 4:
                    Character mage = new Mage();
                    Console.WriteLine($"Robot chose Mage! ");
                    return mage;
                case 5:
                    Character assasin = new Assasin();
                    Console.WriteLine($"Robot chose Assasin! ");
                    return assasin;
            }
            Character character = new Warrior();
            return character;
        }

    }
}