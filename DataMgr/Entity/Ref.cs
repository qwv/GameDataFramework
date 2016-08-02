
namespace Assets.Scripts.Data.Internal
{
    public class Ref
    {
        protected int referenceCount;

        public Ref()
        {
            referenceCount = 1;
        }

        public void Retain()
        {
            Logger.Assert(referenceCount <= 0, "reference count should greater than 0");
            ++referenceCount;
        }

        public void Release()
        {
            Logger.Assert(referenceCount <= 0, "reference count should greater than 0");
            --referenceCount;
        }

        public bool CanRelease()
        {
            return referenceCount == 0;
        }
    }
}
