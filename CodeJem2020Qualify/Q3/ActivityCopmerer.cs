using System.Collections;
using System.Collections.Generic;

namespace CondeJem2020Qualify.Q3
{
    public class ActivityCopmerer : IComparer<Activity>, IComparer
    {
        public int Compare(object x, object y)
        {
            return Compare(x as Activity, y as Activity);
        }

        public int Compare(Activity x, Activity y)
        {
            if (x.Start > y.Start)
                return 1;
            else if (x.Start < y.Start)
                return -1;
            return 0;
        }
    }
}
