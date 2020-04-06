using System;

namespace CondeJem2020Qualify.Q1
{
    public class Vestigium
    {
        private readonly IInputProvider inputProvider;

        public Vestigium(IInputProvider inputProvider)
        {
            this.inputProvider = inputProvider;
        }
        public void Solve()
        {
            var testCases = int.Parse(inputProvider.ReadLine());
            for (int testCase = 1; testCase <= testCases; testCase++)
            {
                var metrix = new Metrix(inputProvider);
                Console.WriteLine($"Case #{testCase}: {metrix.Trace} {metrix.BedRows} {metrix.BedCols}");
            }
        }
    }


}
