using System.Collections.Generic;
using System.Linq;

namespace CondeJem2020Qualify.Q4
{
    public class MemoryFinder
    {
        ArrayModifer arrayModifer = new ArrayModifer();
        private readonly IQ4IO io;
        public int[] MemoryArr { get; private set; }
        public MemoryFinder(IQ4IO io, int B)
        {
            this.io = io;
            MemoryArr = new int[B];
        }

        public string Solve()
        {
            int bitsFound = 0;
            Dictionary<int, int> index2XorValue = new Dictionary<int, int>();
            int xor_0 = 0;
            int xor_1 = 0;
            bool isXor0Valid = false;
            bool isXor1Valid = false;
            for (int i = 0; i < 15; i++)
            {
                if (bitsFound == MemoryArr.Length)
                {
                    break;
                }
                io.WriteLine($"{xor_0 + 1}");
                var arrValForXor0 = int.Parse(io.ReadLine());
                io.WriteLine($"{xor_1 + 1}");
                var arrValForXor1 = int.Parse(io.ReadLine());

                var newAction = GetNewAction(xor_0, xor_1, isXor0Valid, isXor1Valid, arrValForXor0, arrValForXor1);
                MemoryArr = arrayModifer.ArrayModify(newAction, MemoryArr);


                for (int j = 0; j < 4; j++)
                {
                    var fwdIdx = i * 4 + j;
                    var bwdIdx = MemoryArr.Length - 1 - fwdIdx;

                    io.WriteLine($"{fwdIdx + 1}");
                    var fwdValue = int.Parse(io.ReadLine());
                    MemoryArr[fwdIdx] = fwdValue;

                    io.WriteLine($"{bwdIdx + 1}");
                    var bwd1Value = int.Parse(io.ReadLine());
                    MemoryArr[bwdIdx] = bwd1Value;

                    var xorVal = fwdValue ^ bwd1Value;
                    index2XorValue[fwdIdx] = xorVal;
                    if (isXor1Valid == false && xorVal == 1)
                    {
                        xor_1 = fwdIdx;
                        isXor1Valid = true;
                    }
                    else if (isXor0Valid == false && xorVal == 0)
                    {
                        xor_0 = fwdIdx;
                        isXor0Valid = true;
                    }
                    bitsFound += 2;
                    if (bitsFound == MemoryArr.Length)
                    {
                        break;
                    }
                }
            }

            io.WriteLine(new string(MemoryArr.Select(x => (char)(x + '0')).ToArray()));
            return io.ReadLine();
        }


        private ArrayAction GetNewAction(int xor_0, int xor_1, bool isXor0Valid, bool isXor1Valid, int arrValForXor0, int arrValForXor1)
        {
            ArrayAction newAction = ArrayAction.None;

            if (isXor0Valid && isXor1Valid)
            {
                if (arrValForXor0 == MemoryArr[xor_0] && arrValForXor1 == MemoryArr[xor_1])
                {
                    newAction = ArrayAction.None;
                }
                else if (arrValForXor0 == MemoryArr[xor_0] && arrValForXor1 != MemoryArr[xor_1])
                {
                    newAction = ArrayAction.Reverse;
                }
                else if (arrValForXor0 != MemoryArr[xor_0] && arrValForXor1 == MemoryArr[xor_1])
                {
                    newAction = ArrayAction.ReverseComplemented;
                }
                else if (arrValForXor0 != MemoryArr[xor_0] && arrValForXor1 != MemoryArr[xor_1])
                {
                    newAction = ArrayAction.Complemented;
                }
            }
            else if (isXor1Valid)
            {
                if (arrValForXor1 != MemoryArr[xor_1])
                {
                    newAction = ArrayAction.Complemented; // or Complemented
                }
            }
            else if (isXor0Valid)
            {
                if (arrValForXor0 != MemoryArr[xor_0])
                {
                    newAction = ArrayAction.Complemented;
                }
            }

            return newAction;
        }
    }












}
