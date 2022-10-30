namespace Characters
{
    public class Mage : Character
    {
        public Mage()
        {
            Type = "mage";
            MaxHP = 82.5;
            CurrentHP = 82.5;
            AttackDamage = 13;
            Armor = 7;
            Passive = 1; // permanetly increasing damage by 1
        }
        public override void GetPassive()
        {
            CheckCurrentAndMaxHP();
            AttackDamage += Passive;
        }
    }
}
