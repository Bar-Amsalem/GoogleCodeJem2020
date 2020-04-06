using System;

namespace CondeJem2020Qualify.Q4
{
    public class Q4IO : IQ4IO
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Reset()
        {
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

    }












}
