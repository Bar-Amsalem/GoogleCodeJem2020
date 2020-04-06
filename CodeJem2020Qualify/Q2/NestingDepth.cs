using System;

namespace CondeJem2020Qualify.Q2
{
    public class NestingDepth
    {
        private readonly IInputProvider inputProvider;

        public NestingDepth(IInputProvider inputProvider)
        {
            this.inputProvider = inputProvider;
        }
        public void Solve()
        {
            var testCases = int.Parse(inputProvider.ReadLine());
            var stringWrapper = new StringWrapper();
            for (int testCase = 1; testCase <= testCases; testCase++)
            {
                
                var wrappedString = stringWrapper.Wrap(inputProvider.ReadLine().Trim());
                Console.WriteLine($"Case #{testCase}: {wrappedString}");
            }
        }
    }



}
