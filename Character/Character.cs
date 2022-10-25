﻿namespace Characters
{
    public abstract class Character
    {
        // to-do fa attack special pt fiecare categorie cand se strange suficienta ceva
        public string Type { get; set; }
        public double MaxHP { get; set; }
        public double CurrentHP { get; set; }
        public double AttackDamage { get; set; }
        public double Armor { get; set; }
        public double Passive { get; set; }
        public Character()
        {
            Type = nameof(Character);
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


        // to-do ar trebui si celelalte combinatii de clase testate?
        // muta treaba asta in fiecare clasa copil
        public abstract void GetPassivesAndCounters(Character character, ref double extraDamage);

    }

}