using System;
using System.Collections.Generic;

namespace CondeJem2020Qualify.Q4.Sim
{
    public class CacheRandomMemoryChanger : RandomMemoryChanger
    {
        public Queue<ArrayAction> AllActions = new Queue<ArrayAction>();

        readonly ArrayAction[] allActions = new ArrayAction[]
        {
            ArrayAction.Complemented,
            ArrayAction.Reverse,
            ArrayAction.ReverseComplemented,
            ArrayAction.None
        };

        Random random = new Random((int)DateTime.Now.TimeOfDay.TotalSeconds);
        public override ArrayAction GetActionToPreform()
        {
            var action = allActions[random.Next(0, 3)];
            AllActions.Enqueue(action);
            return action;
        }
    }




}
