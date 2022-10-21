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

    }
}
