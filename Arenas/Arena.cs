using Characters;

namespace Arenas
{
    public class Arena
    {
        public bool isHPZero(ref ICharacter character)
        {
            return character.CurrentHP <= 0;
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
        public void ResetPassives(ref ICharacter character)
        {
            switch (character.Type)
            {
                case "archer":

                    break;
                case "assasin":
                    if (character.AttackDamage >= 20)
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
        public void GetPassivesAndCounters(ref ICharacter character, string characterType, string oponentCharacterType, string? playerName)
        {
            switch (characterType)
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
                        character.CurrentHP -= 5; //assasin counters archer
                        Console.WriteLine("The Assasin dealt 5 extra damage");

                    }
                    break;
                case "assasin":
                    isCurrentHpGTthanMaxHP(ref character);
                    Random random = new Random();
                    int lucky = random.Next(0, 21);

                    if (lucky == 20)
                    {
                        character.AttackDamage += character.Passive;
                    }
                    if (oponentCharacterType == "warrior")
                    {
                        character.CurrentHP -= 4; // warrior counters assasin
                        Console.WriteLine("The warrior dealt 4 extra damage");
                    }
                    break;
                case "healer":
                    isCurrentHpGTthanMaxHP(ref character);

                    character.CurrentHP += character.Passive;
                    Console.WriteLine($"{playerName} healed {character.Passive} HP");
                    if (oponentCharacterType == "assasin")
                    {
                        character.CurrentHP -= 5; // assasin counters healer
                        Console.WriteLine("The Assasin dealt 5 extra damage");

                    }
                    break;
                case "mage":
                    isCurrentHpGTthanMaxHP(ref character);
                    character.AttackDamage += character.Passive;
                    if (oponentCharacterType == "healer")
                    {
                        character.CurrentHP -= 3; // healer counter mage
                        Console.WriteLine("The Healer dealt 3 extra damage");
                    }
                    break;
                case "warrior":
                    isCurrentHpGTthanMaxHP(ref character);
                    character.Armor += character.Passive;
                    if (oponentCharacterType == "archer")
                    {
                        character.CurrentHP -= 3; // archer counters warrior
                        Console.WriteLine("The Archer dealt 3 extra damage");
                    }
                    break;
            }
        }
        public double GetRandomNumbers(double min, double max)
        {
            Random random = new Random();
            return random.NextDouble() * (max - min) + min;
        }
        public ICharacter RobotChoise()
        {
            Random random = new Random((int)(DateTime.Now.Ticks));
            int number = random.Next(1, 5);
            switch (number)
            {
                case 1:
                    Warrior warrior = new Warrior();
                    Console.WriteLine($"Robot chose Warrior!");
                    return warrior;
                case 2:
                    Archer archer = new Archer();
                    Console.WriteLine($"Robot chose Archer! ");
                    return archer;
                case 3:
                    Healer healer = new Healer();
                    Console.WriteLine($"Robot chose Healer! ");
                    return healer;
                case 4:
                    Mage mage = new Mage();
                    Console.WriteLine($"Robot chose Mage! ");
                    return mage;
                case 5:
                    Assasin assasin = new Assasin();
                    Console.WriteLine($"Robot chose Assasin! ");
                    return assasin;
            }
            return null;
        }
        public void Fight(ICharacter playerCharacter, string? playerName)
        {


            ICharacter robotCharacter = RobotChoise();
            string robotName = "Cici";

            Random random = new Random((int)(DateTime.Now.Ticks));
            int numberToStartTurn = random.Next(1, 3);
            if (numberToStartTurn == 1)
            {
                Console.WriteLine($"First Turn: {playerName}");
            }
            else
            {
                Console.WriteLine($"First Turn: {robotName}");
            }


            int turns = 1;
            while (isHPZero(ref playerCharacter) == false & isHPZero(ref robotCharacter) == false)
            {
                double copieRobotCurrentHP = robotCharacter.CurrentHP;
                double copiePlayerCurrentHP = playerCharacter.CurrentHP;

                switch (numberToStartTurn)
                {
                    case 1:
                        // player hit first
                        GetPassivesAndCounters(ref robotCharacter, robotCharacter.Type, playerCharacter.Type, robotName);
                        robotCharacter.CurrentHP -= DamageDealt(ref playerCharacter, ref robotCharacter);
                        Console.WriteLine($"{playerName} dealt {(copieRobotCurrentHP - robotCharacter.CurrentHP):N2}");
                        ResetPassives(ref playerCharacter);
                        if (isHPZero(ref robotCharacter) == true)
                        {
                            break;
                        }
                        Console.WriteLine();

                        //robot turn
                        GetPassivesAndCounters(ref playerCharacter, playerCharacter.Type, robotCharacter.Type, playerName);
                        playerCharacter.CurrentHP -= DamageDealt(ref robotCharacter, ref playerCharacter);
                        Console.WriteLine($"{robotName} dealt {(copiePlayerCurrentHP - playerCharacter.CurrentHP):N2}");
                        ResetPassives(ref robotCharacter);
                        if (isHPZero(ref playerCharacter) == true)
                        {
                            break;
                        }
                        Console.WriteLine();

                        break;
                    case 2:
                        // robot hit first
                        GetPassivesAndCounters(ref playerCharacter, playerCharacter.Type, robotCharacter.Type, playerName);
                        playerCharacter.CurrentHP -= DamageDealt(ref robotCharacter, ref playerCharacter);
                        Console.WriteLine($"{robotName} dealt {(copiePlayerCurrentHP - playerCharacter.CurrentHP):N2}");
                        ResetPassives(ref robotCharacter);
                        if (isHPZero(ref robotCharacter) == true)
                        {
                            break;
                        }
                        Console.WriteLine();

                        // player turn
                        GetPassivesAndCounters(ref robotCharacter, robotCharacter.Type, playerCharacter.Type, robotName);
                        robotCharacter.CurrentHP -= DamageDealt(ref playerCharacter, ref robotCharacter);
                        Console.WriteLine($"{playerName} dealt {(copieRobotCurrentHP - robotCharacter.CurrentHP):N2}");
                        ResetPassives(ref playerCharacter);
                        if (isHPZero(ref playerCharacter) == true)
                        {
                            break;
                        }
                        Console.WriteLine();


                        break;
                }
                // TO DO xp

                //Console.WriteLine($"{playerName} dealt {(copieRobotHP - robotCharacter.CurrentHP):N2}");
                //Console.WriteLine($"Robot dealt {(copiePlayerHP - playerCharacter.CurrentHP):N2}");


                if (turns == 30)
                {
                    break;
                }
                turns++;
            }
            if (playerCharacter.CurrentHP <= 0)
            {
                Console.WriteLine($"Sorry {playerName}, you lost the duel");
            }
            else if (robotCharacter.CurrentHP <= 0)
            {
                Console.WriteLine($"congratulation {playerName}, you won!");
            }
            else
            {
                Console.WriteLine("DRAW");
            }

            Console.WriteLine(turns);

        }
    }
}