using Characters;

namespace Arenas
{
    //nu cred ca clasa asta face ceva. PrintMessageOnHit are 0 references
    public class Notifier
    {
        public delegate void GettingHitEventHandler(object source, EventArgs args);
        public event  GettingHitEventHandler? GettingHit;

        //ref-uri inutile & parametri inutili
        public void PrintMessageOnHit(ref string? name, ref double opponentCurrentHp, ref Character opponent, ref double damage)
        {
            OnGettingHit();
        }
        protected virtual void OnGettingHit()
        {
            if (GettingHit != null)
                GettingHit(this, EventArgs.Empty);
        }
    }
}
