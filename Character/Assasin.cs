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
        public override void GetPassive( )
        {
            if(AttackDamage >= 40)
            {
                AttackDamage = 20;
            }
            CheckCurrentAndMaxHP();
            Random random = new Random();
            int lucky = random.Next(0, 11);

            if (lucky == 7)
            {
                AttackDamage += Passive;
            }
        }
    }
}
