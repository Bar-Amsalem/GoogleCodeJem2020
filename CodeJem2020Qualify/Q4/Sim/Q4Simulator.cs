using System;
using System.Collections.Generic;
using System.Linq;

namespace CondeJem2020Qualify.Q4.Sim
{
    public class Q4Simulator : IQ4IO
    {
        protected int query = 1;
        protected Queue<char> outputBuffer = new Queue<char>();
        public int[] MemoryArray { get; private set; }
        readonly int[] org;

        protected readonly IMemoryChanger memoryChanger;
        protected bool ErrorOccuer = false;
        protected readonly ArrayModifer modifer = new ArrayModifer();
        protected string memoryArrayStr { get { return new string(MemoryArray.Select(x => (char)(x + '0')).ToArray()); } }


        public Q4Simulator(int[] memoryArray, IMemoryChanger memoryChanger)
        {
            
            this.org = memoryArray;
            this.memoryChanger = memoryChanger;
            Reset();
        }

        public void Reset()
        {
            query = 1;
            outputBuffer = new Queue<char>();
            MemoryArray = new int[org.Length];
            org.CopyTo(MemoryArray, 0);
            ErrorOccuer = false;

        }

        public virtual string ReadLine()
        {
            return outputBuffer.Dequeue().ToString();
        }

        public void WriteLine(string message)
        {
            if (ErrorOccuer)
                throw new InvalidOperationException("You have a mistke, system is closed");


            if (query % 10 == 1)
            {
                MemoryArray = modifer.ArrayModify(memoryChanger.GetActionToPreform(), MemoryArray);
            }

            if (message.Length > 4)
            {
                var answer = memoryArrayStr == message ? 'Y' : 'N';
                outputBuffer.Enqueue(answer);
                if (answer == 'N')
                {
                    ErrorOccuer = true;
                }
            }
            else
            {
                if (query == 150)
                {
                    ErrorOccuer = true;
                    throw new InvalidOperationException("You have a reach the max guess of 150, system is closed");
                }
                query++;
                int idx = int.Parse(message);
                try
                {
                    var temp = MemoryArray[idx - 1];
                    outputBuffer.Enqueue((char)('0' + temp));
                }
                catch (IndexOutOfRangeException)
                {
                    outputBuffer.Enqueue('N');
                    ErrorOccuer = true;
                }
            }
        }

      
    }




}
