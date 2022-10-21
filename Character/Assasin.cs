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

    }
}
