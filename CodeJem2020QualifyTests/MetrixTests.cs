using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using CondeJem2020Qualify.Q1;

namespace CondeJem2020Qualify.Tests
{
  
    [TestClass()]
    public class MetrixTests
    {
        [TestMethod]
        public void VestigiumTests()
        {
            var vestigium = new Vestigium(new VestigiumInMemoryInputProiveder(4));
            vestigium.Solve();
        }



        [TestMethod()]
        public void MetrixTest()
        {
            var metrix1 = new Metrix(new VestigiumInMemoryInputProiveder(1));
            Assert.AreEqual(4, metrix1.Trace);
            Assert.AreEqual(0, metrix1.BedRows);
            Assert.AreEqual(0, metrix1.BedCols);

            var metrix2 = new Metrix(new VestigiumInMemoryInputProiveder(2));
            Assert.AreEqual(9, metrix2.Trace);
            Assert.AreEqual(4, metrix2.BedRows);
            Assert.AreEqual(4, metrix2.BedCols);

            var metrix3 = new Metrix(new VestigiumInMemoryInputProiveder(3));
            Assert.AreEqual(8, metrix3.Trace);
            Assert.AreEqual(0, metrix3.BedRows);
            Assert.AreEqual(2, metrix3.BedCols);
        }
    }


    public class VestigiumInMemoryInputProiveder : IInputProvider
    {
        string[] currentTestCase;
        int lastLine = 0;
        string[] testCase1 = new string[]
        {
            "4",
            "1 2 3 4",
            "2 1 4 3",
            "3 4 1 2",
            "4 3 2 1",
        };

        string[] testCase2 = new string[]
        {
            "4",
            "2 2 2 2",
            "2 3 2 3",
            "2 2 2 3",
            "2 2 2 2",
        };

        string[] testCase3 = new string[]
       {
            "3",
            "2 1 3",
            "1 3 2",
            "1 2 3",
       };

        string[] testCase4 = new string[]
       {
            "3",
            "4",
            "1 2 3 4",
            "2 1 4 3",
            "3 4 1 2",
            "4 3 2 1",
            "4",
            "2 2 2 2",
            "2 3 2 3",
            "2 2 2 3",
            "2 2 2 2",
            "3",
            "2 1 3",
            "1 3 2",
            "1 2 3",
       };

        public VestigiumInMemoryInputProiveder(int testCase)
        {
            switch (testCase)
            {
                case 1:
                    currentTestCase = testCase1;
                    break;
                case 2:
                    currentTestCase = testCase2;
                    break;
                case 3:
                    currentTestCase = testCase3;
                    break;  
                case 4:
                    currentTestCase = testCase4;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(testCase));
            }

        }

        public string ReadLine()
        {
            if (lastLine < currentTestCase.Length)
            {
                return currentTestCase[lastLine++];
            }
            else
            {
                return "";
            }
        }
    }
}