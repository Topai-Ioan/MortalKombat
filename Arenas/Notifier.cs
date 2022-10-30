using Characters;

namespace Arenas
{
    public class Notifier
    {
        public delegate void GettingHitEventHandler(object source, EventArgs args);
        public event  GettingHitEventHandler? GettingHit;

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
