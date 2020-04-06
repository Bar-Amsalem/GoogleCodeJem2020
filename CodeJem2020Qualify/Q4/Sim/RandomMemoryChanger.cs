using System;

namespace CondeJem2020Qualify.Q4.Sim
{
    public class RandomMemoryChanger : IMemoryChanger
    {
        readonly ArrayAction[] allActions = new ArrayAction[]
        {
            ArrayAction.Complemented,
            ArrayAction.Reverse,
            ArrayAction.ReverseComplemented,
            ArrayAction.None
        };

        Random random = new Random((int)DateTime.Now.TimeOfDay.TotalSeconds);
        public virtual ArrayAction GetActionToPreform()
        {
            return allActions[random.Next(0, 3)];
        }
    }




}
