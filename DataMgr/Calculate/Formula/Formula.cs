
namespace Assets.Scripts.Data.Internal
{
    public abstract class Formula
    {
        protected float result;

        public float Result
        {
            get { return result; }
        }

        public abstract void Calculate(CalPropsEntity attacker, CalPropsEntity target); 
    }
}
