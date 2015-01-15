using System.Collections.Generic;

namespace WindowsPathExtender.Loader
{
    public class ListExt<T> : List<T>
    {
        public T First
        {
            get { return this[0]; }
            set { this[0] = value; }
        }

        public T Last
        {
            get { return this[Count - 1]; }
            set { this[Count - 1] = value; }
        }

        public T FirstOrDefault
        {
            get { return Count > 0 ? this[0] : default(T); }
            set
            {
                if (Count > 0) this[0] = value;
                else Add(value);
            }
        }

        public T LastOrDefault
        {
            get { return Count > 0 ? this[Count - 1] : default(T); }
            set
            {
                if (Count > 0) this[Count - 1] = value;
                else Add(value);
            }
        }
    }
}
