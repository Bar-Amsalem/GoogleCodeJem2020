using System;
using System.Collections.Generic;
using System.Linq;

namespace CondeJem2020Qualify.Q3
{
    public class Scheduler
    {
        private readonly IInputProvider inputProvider;
        public Scheduler(IInputProvider inputProvider)
        {
            this.inputProvider = inputProvider;
        }

        public string CreateSchedule(IEnumerable<Parent> parents, Clock clock)
        {
            var nActivities = int.Parse(inputProvider.ReadLine());
            var activities = new Activity[nActivities];
            for (int i = 0; i < nActivities; i++)
            {
                activities[i] = new Activity(inputProvider.ReadLine(), i);
            }
            Array.Sort<Activity>(activities, new ActivityCopmerer());
            var maxTime = activities.Max(act => act.Stop);

            
            int taskIdx = 0;
            char[] result = new char[nActivities];
            for (; clock.Time <= maxTime; )
            {
                if (activities[taskIdx].Start == clock.Time)
                {
                    bool assaind = false;
                    foreach (var parent in parents)
                    {
                        if(!parent.IsBusy)
                        {
                            result[activities[taskIdx].ID] = parent.Name;
                            parent.AssainActivity = activities[taskIdx++];
                            assaind = true;
                            break;

                        }
                    }

                    if(!assaind)
                    {
                        return "IMPOSSIBLE";
                    }

                    if(taskIdx == activities.Length)
                    {
                        break;
                    }
                    continue;
                }
                clock.Tick();
            }

            return new string(result);

        }
    }
}
