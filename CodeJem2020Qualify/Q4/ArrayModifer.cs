using System;
using System.Linq;

namespace CondeJem2020Qualify.Q4
{
    public class ArrayModifer
    {
        public int[] ArrayModify(ArrayAction action, int[] arr)
        {
            int[] result = null;
            switch (action)
            {
                case ArrayAction.Complemented:
                    result = arr.Select(x => 1 - x).ToArray();
                    break;
                case ArrayAction.Reverse:
                    result = arr.Reverse().ToArray();
                    break;
                case ArrayAction.ReverseComplemented:
                    result = arr.Select(x => 1 - x).Reverse().ToArray();
                    break;
                default:
                    result = arr.Select(x => x).ToArray();
                    break;
            }
            return result;
        }
    }












}
