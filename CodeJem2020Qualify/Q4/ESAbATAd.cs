using System;

namespace CondeJem2020Qualify.Q4
{
    public class ESAbATAd
    {
        private readonly IQ4IO inputProvider;
        public MemoryFinder MemoryFinder { get; private set; }
        public ESAbATAd(IQ4IO inputProvider)
        {
            this.inputProvider = inputProvider;
        }
        public string Solve()
        {
            var raw = inputProvider.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var testCases = int.Parse(raw[0]);
            var B = int.Parse(raw[1]);
            MemoryFinder = new MemoryFinder(inputProvider, B);
            for (int testCase = 1; testCase <= testCases; testCase++)
            {
                inputProvider.Reset();
                var res = MemoryFinder.Solve();
                if (res == "N")
                    return "N";
            }
            return "Y";

        }
    }












}
