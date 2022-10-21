namespace Characters
{
    public class Archer : ICharacter
    {
        public string Type { get; set; }
        public double MaxHP { get; set; }
        public double CurrentHP { get; set; }
        public double AttackDamage { get; set; }
        public double Armor { get; set; }
        public double Passive { get; set; }
        public Archer()
        {
            Type = "archer";
            MaxHP = 90;
            CurrentHP = 90;
            AttackDamage = 12;
            Armor = 3;
            Passive = 1; // 50% change to incresease damage by 2 each turn;
        }

    }
}
