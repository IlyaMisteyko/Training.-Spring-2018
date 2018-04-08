using System;

namespace JaggedArrayLib
{
    public static class Converter
    {
        public static DelegateToInterface NewDelegate(Delegate del)
        {
            return new DelegateToInterface(del);
        }

        public class DelegateToInterface: IComparer
        {
            private Delegate del;

            public DelegateToInterface(Delegate del)
            {
                this.del = del;
            }

            public int Compare(int[] first, int[] second)
            {
                return del.Invoke(first, second);
            }
        }
    }
}