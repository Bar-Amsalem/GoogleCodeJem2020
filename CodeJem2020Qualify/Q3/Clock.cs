namespace CondeJem2020Qualify.Q3
{
    public class Clock
    {

        public void Tick()
        {
            Time++;
        }

        public void Reset()
        {
            Time = 0;
        }

        public ulong Time { get; private set; } = 0;


    }
}
