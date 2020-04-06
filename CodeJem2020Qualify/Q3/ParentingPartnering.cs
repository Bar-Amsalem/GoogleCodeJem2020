using System;
using System.Linq;

namespace CondeJem2020Qualify.Q3
{
    public class ParentingPartnering
    {
        private readonly IInputProvider inputProvider;

        public ParentingPartnering(IInputProvider inputProvider)
        {
            this.inputProvider = inputProvider;

        }

        public void Solve()
        {
            var testCases = int.Parse(inputProvider.ReadLine());
            Clock clock = new Clock();

            var parents = new Parent[2]
            {
                new Parent('C', clock),
                new Parent('J', clock)
            };
            Scheduler scheduler = new Scheduler(inputProvider);
            for (int testCase = 1; testCase <= testCases; testCase++)
            {
                clock.Reset();
                foreach (var parent in parents)
                {
                    parent.AssainActivity = null;
                }
                var schedule = scheduler.CreateSchedule(parents, clock);

                Console.WriteLine($"Case #{testCase}: {schedule}");
            }
        }
    }

    public class Activity
    {
        public Activity(string str,int id)
        {
            var parts = str.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => ulong.Parse(x)).ToArray();
            Start = parts[0];
            Stop = parts[1];
            ID = id;
        }
        public int ID { get; }
        public ulong Start { get; }
        public ulong Stop { get; }
    }
}
