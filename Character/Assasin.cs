namespace Characters
{
    public class Assasin : Character
    {

        public Assasin()
        {
            Type = "assasin";
            MaxHP = 80;
            CurrentHP = 80;
            AttackDamage = 20;
            Armor = 5;
            Passive = 20; // 10 % of +20 damage
        }
        public override void GetPassivesAndCounters(Character character, ref double extraDamage)
        {
            Console.WriteLine("intra pe aici ?");
            CheckCurrentAndMaxHP();
            Random random = new Random();
            int lucky = random.Next(0, 11);

            if (lucky == 7)
            {
                AttackDamage += Passive;
            }
            switch (character.Type)
            {
                case "archer":
                    extraDamage = 3;
                    break;
                case "assasin":
                    break;
                case "healer":
                    extraDamage = 3;
                    break;
                case "mage":
                    break;
                case "warrior":
                    CurrentHP -= 2; // warrior counters assasin
                    AttackDamage = 25;
                    Armor = 7;
                    break;

            }
        }
    }
}
