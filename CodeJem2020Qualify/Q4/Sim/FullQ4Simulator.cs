namespace CondeJem2020Qualify.Q4.Sim
{
    public class FullQ4Simulator : Q4Simulator
    {
        bool isFirst = true;
        readonly int T;
        public FullQ4Simulator(int[] memoryArray, IMemoryChanger memoryChanger, int T) : base(memoryArray, memoryChanger)
        {
            this.T = T;
        }

        public override string ReadLine()
        {
            if(isFirst)
            {
                isFirst = false;
                return $"{T} {MemoryArray.Length}";
            }
            return base.ReadLine();
        }

    }




}
