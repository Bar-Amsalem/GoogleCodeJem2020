using System;

namespace CondeJem2020Qualify
{
    public class ConsoleInputProvider: IInputProvider
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }


}
