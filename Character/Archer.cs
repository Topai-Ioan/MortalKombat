namespace Characters
{
    public class Archer : Character
    {

        public Archer()
        {
            Type = "archer";
            MaxHP = 90;
            CurrentHP = 90;
            AttackDamage = 10;
            Armor = 3;
            Passive = 1; // 50% change to incresease damage by 2 each turn;
        }

        public override void GetPassivesAndCounters(Character character, ref double extraDamage)
        {
            CheckCurrentAndMaxHP();
            Random zeroOrOne = new Random();
            Passive = zeroOrOne.Next(1, 3);
            if (Passive == 1)
            {
                AttackDamage += 2;
            }
            switch (character.Type)
            {
                case "archer":
                    break;
                case "assasin":
                    CurrentHP -= 3; //assasin counters archer
                    Armor = 17;
                    break;
                case "healer":
                    break;
                case "mage":
                    break;
                case "warrior":
                    extraDamage = 3;
                    break;

            }
        }

    }
}
