namespace Characters
{
    public class Warrior : Character
    {
        public Warrior()
        {
            Type = "warrior";
            MaxHP = 100;
            CurrentHP = 100;
            AttackDamage = 10;
            Armor = 10;
            Passive = 1.25; //permanetly incresing armor by 10%
        }

        public override void GetPassive()
        {
            CheckCurrentAndMaxHP();
            Armor += Passive;
        }
    }
}

