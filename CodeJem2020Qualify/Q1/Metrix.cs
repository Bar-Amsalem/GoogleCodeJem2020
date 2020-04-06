using System;
using System.Collections.Generic;
using System.Linq;

namespace CondeJem2020Qualify.Q1
{
    public class Metrix
    {
        readonly long[,] metrix;
        readonly long N;
        public Metrix(IInputProvider inputProvider)
        {
            N = long.Parse(inputProvider.ReadLine());
            metrix = new long[N, N];
            for (int i = 0; i < N; i++)
            {
                var line = inputProvider.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(m => long.Parse(m)).ToArray();
                for (int j = 0; j < N; j++)
                {
                    metrix[i, j] = line[j];
                }
            }
        }

        public long Trace
        {
            get
            {
                long sum = 0;
                for (int i = 0; i < N; i++)
                {
                    sum += metrix[i, i];
                }
                return sum;
            }
        }

        public long BedRows
        {
            get
            {
                long bedRows = 0;
                Dictionary<long, bool> findItems = new Dictionary<long, bool>();
                for (int i = 0; i < N; i++)
                {
                    findItems.Clear();
                    for (int j = 0; j < N; j++)
                    {
                        if (findItems.ContainsKey(metrix[i, j]))
                        {
                            bedRows++;
                            break;
                        }
                        else
                        {
                            findItems[metrix[i, j]] = true;
                        }
                    }
                }
                return bedRows;
            }
        }

        public long BedCols
        {
            get
            {
                long bedCols = 0;
                Dictionary<long, bool> findItems = new Dictionary<long, bool>();
                for (int i = 0; i < N; i++)
                {
                    findItems.Clear();
                    for (int j = 0; j < N; j++)
                    {
                        if (findItems.ContainsKey(metrix[j, i]))
                        {
                            bedCols++;
                            break;
                        }
                        else
                        {
                            findItems[metrix[j, i]] = true;
                        }
                    }
                }
                return bedCols;
            }
        }

    }


}
