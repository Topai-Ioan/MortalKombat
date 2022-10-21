namespace Characters
{
    public class Character
    {

        public string Type { get; set; }
        public double MaxHP { get; set; }
        public double CurrentHP { get; set; }
        public double AttackDamage { get; set; }
        public double Armor { get; set; }
        public double Passive { get; set; }
        public Character()
        {
            Type = "default";
            MaxHP = 0;
            CurrentHP = 0;
            AttackDamage = 0;
            Armor = 0;
            Passive = 0;
        }
        
        public void Hit(Character opponent)
        {
            int min = 0;
            int max = 2;
            Random random = new Random();
            double randomDamage = random.NextDouble() * (max - min) + min;
            opponent.CurrentHP -= (AttackDamage * 10) / (opponent.Armor + 10) + randomDamage;
        }
        public bool isHPZeroOrLess()
        {
            return CurrentHP <= 0;
        }

        public void CheckCurrentAndMaxHP()
        {
            if (CurrentHP > MaxHP)
            {
                CurrentHP = MaxHP;
            }
        }

        public void ResetPassive()
        {
            switch (Type)
            {
                case "archer":

                    break;
                case "assasin":
                    if (AttackDamage >= 40)
                    {
                        AttackDamage -= Passive;
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

        public void TryToLevelUp(ref int stepForLevelingUp, double totalDamage, string? Name)
        {
            if (totalDamage % 30 < 30 && totalDamage > 30 + stepForLevelingUp)
            {
                stepForLevelingUp += 50;
                CurrentHP = CurrentHP + 0.1 * MaxHP;
                AttackDamage *= 1.2;
                Armor *= 1.2;
                Passive *= 1.2;
                Console.WriteLine($"{Name} has leveled up!");
            }
        }


        public void GetPassivesAndCounters(string oponentCharacterType, ref double extraDamage)
        {
            switch (Type)
            {
                case "archer":
                    CheckCurrentAndMaxHP();
                    Random zeroOrOne = new Random();
                    Passive = zeroOrOne.Next(1, 3);
                    if (Passive == 1)
                    {
                        AttackDamage += 2;
                    }
                    if (oponentCharacterType == "assasin")
                    {
                        CurrentHP -= 3; //assasin counters archer
                        Armor = 17;
                    }
                    if (oponentCharacterType == "warrior")
                    {
                        extraDamage = 3;
                    }

                    break;
                case "assasin":
                    CheckCurrentAndMaxHP();
                    Random random = new Random();
                    int lucky = random.Next(0, 11);

                    if (lucky == 7)
                    {
                        AttackDamage +=  Passive;
                    }
                    if (oponentCharacterType == "warrior")
                    {
                         CurrentHP -= 2; // warrior counters assasin
                         AttackDamage = 25;
                         Armor = 7;
                    }
                    if (oponentCharacterType == "healer" || oponentCharacterType == "archer")
                    {
                        extraDamage = 3;
                    }
                    break;
                case "healer":
                     CheckCurrentAndMaxHP();


                    if (oponentCharacterType == "assasin")
                    {
                         CurrentHP -= 3; // assasin counters healer
                         Armor = 6;
                         Passive = 10.5;
                         AttackDamage = 10.2;
                    }
                    if (oponentCharacterType == "archer")
                    {
                         Armor = 6;
                         Passive = 7;
                    }
                    if (oponentCharacterType == "warrior")
                    {
                         AttackDamage = 7.5;
                         Armor = 4.25;
                         Passive = 6;
                    }
                    if (oponentCharacterType == "mage")
                    {
                        extraDamage = 2;
                    }
                    CurrentHP += Passive;
                    Console.WriteLine($"Healer healed {Passive} HP");

                    break;
                case "mage":
                     CheckCurrentAndMaxHP();
                     AttackDamage +=  Passive;
                    if (oponentCharacterType == "healer")
                    {
                         CurrentHP -= 2; // healer counter mage
                         AttackDamage = 14;
                         Armor = 7;
                    }
                    if (oponentCharacterType == "assasin")
                    {
                         Armor = 9;
                    }
                    if (oponentCharacterType == "archer")
                    {
                         AttackDamage = 12;
                    }
                    break;
                case "warrior":
                     CheckCurrentAndMaxHP();
                     Armor +=  Passive;
                    if (oponentCharacterType == "archer")
                    {
                         CurrentHP -= 3; // archer counters warrior
                    }
                    if (oponentCharacterType == "assasin")
                    {
                        extraDamage = 2;
                    }
                    break;
            }
        }

    }

}