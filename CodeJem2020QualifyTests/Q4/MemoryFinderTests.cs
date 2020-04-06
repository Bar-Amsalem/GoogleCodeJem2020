using Microsoft.VisualStudio.TestTools.UnitTesting;
using CondeJem2020Qualify.Q4;
using System;
using System.Collections.Generic;
using System.Text;
using CondeJem2020Qualify.Q4.Sim;
using System.Linq;

namespace CondeJem2020Qualify.Q4.Tests
{
    [TestClass()]
    public class MemoryFinderTests
    {
        [TestMethod()]
        public void SolveTest1()
        {
            int[] arr = new[] { 1, 0, 1, 1, 0, 0, 0, 1, 0, 1 };
            var simuator = new Q4Simulator(arr, new TestMemoryChanger());

            MemoryFinder memoryFinder = new MemoryFinder(simuator, arr.Length);
            var res = memoryFinder.Solve();
            Assert.AreEqual("Y", res);
        }


        [TestMethod()]
        public void SolveTest2()
        {
            int[] arr = new[] { 1, 0, 0, 1, 0, 1, 1, 1, 0, 1 };
            var simuator = new Q4Simulator(arr, new TestMemoryChanger());

            MemoryFinder memoryFinder = new MemoryFinder(simuator, arr.Length);
            var res = memoryFinder.Solve();
            Assert.AreEqual("Y", res);
        }


        [TestMethod()]
        public void SolveTest3()
        {
            int[] arr = new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            var simuator = new Q4Simulator(arr, new TestMemoryChanger());

            MemoryFinder memoryFinder = new MemoryFinder(simuator, arr.Length);
            var res = memoryFinder.Solve();
            Assert.AreEqual("Y", res);
        }



        [TestMethod()]
        public void SolveTest4()
        {
            int[] arr = new[] { 1, 1, 1, 0, 1, 1, 1, 0, 0, 1 };
            var simuator = new Q4Simulator(arr, new RandomMemoryChanger());

            MemoryFinder memoryFinder = new MemoryFinder(simuator, arr.Length);
            var res = memoryFinder.Solve();
            Assert.AreEqual("Y", res);
        }


        [TestMethod()]
        public void SolveTest5()
        {
            int[] arr = new[] { 1, 0, 0, 1, 0, 1, 1, 1, 0, 1,
                                1, 1, 1, 1, 0, 1, 0, 0, 0, 0};
            var simuator = new Q4Simulator(arr, new TestMemoryChanger());

            MemoryFinder memoryFinder = new MemoryFinder(simuator, arr.Length);
            var res = memoryFinder.Solve();
            Assert.AreEqual("Y", res);
        }

        [TestMethod()]
        public void SolveTest6()
        {
            int[] arr = new[] {
                 1, 0, 0, 1, 0, 1, 1, 1, 0, 1,
                1, 1, 1, 1, 0, 1, 0, 0, 0, 0,
                 1, 0, 0, 1, 0, 1, 1, 1, 0, 1,
                1, 1, 1, 1, 0, 1, 0, 0, 0, 0,
                 1, 0, 0, 1, 0, 1, 1, 1, 0, 1,
                1, 1, 1, 1, 0, 1, 0, 0, 0, 0,
                 1, 0, 0, 1, 0, 1, 1, 1, 0, 1,
                1, 1, 1, 1, 0, 1, 0, 0, 0, 0,
                 1, 0, 0, 1, 0, 1, 1, 1, 0, 1,
                1, 1, 1, 1, 0, 1, 0, 0, 0, 0,
            };
            var simuator = new Q4Simulator(arr, new TestMemoryChanger());

            MemoryFinder memoryFinder = new MemoryFinder(simuator, arr.Length);
            var res = memoryFinder.Solve();
            Assert.AreEqual("Y", res);
        }

        [TestMethod()]
        public void SolveTest7()
        {
            int[] arr = new[] {
                 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                1, 1, 1, 1, 0, 0, 0, 0, 0, 0,
                 1, 0, 0, 1, 0, 1, 1, 1, 0, 1,
                1, 1, 1, 1, 0, 1, 0, 0, 0, 0,
                 1, 0, 0, 1, 0, 1, 1, 1, 0, 1,
                1, 1, 0, 0, 0, 1, 0, 0, 0, 0,
                 1, 0, 0, 1, 0, 1, 1, 1, 0, 1,
                1, 0, 1, 1, 0, 1, 0, 0, 0, 1,
                 1, 0, 0, 1, 0, 1, 1, 1, 0, 1,
                1, 1, 1, 1, 0, 1, 0, 0, 0, 0,
            };
            var simuator = new FullQ4Simulator(arr, new TestMemoryChanger(), 1);
            ESAbATAd sol = new ESAbATAd(simuator);
            var res = sol.Solve();
        }
        [TestMethod()]
        public void SolveTest8()
        {
            int[] arr = new[] { 0, 1, 1, 0, 0, 0, 0, 1, 0, 1 };
            ArrayModifer modifer = new ArrayModifer();
            for (int i = 1; i <= 100; i++)
            {
                if(i % 10  == 0)
                {
                    arr = modifer.ArrayModify((ArrayAction)(i / 10), arr);
                }
                var simuator = new FullQ4Simulator(arr, new CacheRandomMemoryChanger(), 1);
                ESAbATAd sol = new ESAbATAd(simuator);
                var res = sol.Solve();
                var expected = new string(simuator.MemoryArray.Select(x => (char)(x + '0')).ToArray());
                var actual = new string(sol.MemoryFinder.MemoryArr.Select(x => (char)(x + '0')).ToArray());
                try
                {
                    Assert.AreEqual("Y", res);

                }
                catch (Exception)
                {

                    throw;
                }

            }


        }
    }
}