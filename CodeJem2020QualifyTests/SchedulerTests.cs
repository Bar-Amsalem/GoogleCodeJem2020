using Microsoft.VisualStudio.TestTools.UnitTesting;
using CondeJem2020Qualify;
using System;
using System.Collections.Generic;
using System.Text;
using CondeJem2020Qualify.Q3;

namespace CondeJem2020Qualify.Tests
{
    [TestClass()]
    public class SchedulerTests
    {
        [TestMethod]
        public void ParentingPartneringTest()
        {
            var inputProvider = new SchedulerInMemoryInputProiveder(5);
            var parentingPartnering = new ParentingPartnering(inputProvider);

            parentingPartnering.Solve();
        }


        [TestMethod()]
        public void CreateSchedule1Test()
        {
            var inputProvider = new SchedulerInMemoryInputProiveder(1);
            Clock clock = new Clock();
            var parents = new Parent[2]
            {
                new Parent('C', clock),
                new Parent('J', clock)
            };
            Scheduler scheduler = new Scheduler(inputProvider);
            Assert.AreEqual("CJC", scheduler.CreateSchedule(parents, clock));
        }

        [TestMethod()]
        public void CreateSchedule2Test()
        {
            var inputProvider = new SchedulerInMemoryInputProiveder(2);
            Clock clock = new Clock();
            var parents = new Parent[2]
            {
                new Parent('C', clock),
                new Parent('J', clock)
            };
            Scheduler scheduler = new Scheduler(inputProvider);
            Assert.AreEqual("IMPOSSIBLE", scheduler.CreateSchedule(parents, clock));
        }

        [TestMethod()]
        public void CreateSchedule3Test()
        {
            var inputProvider = new SchedulerInMemoryInputProiveder(3);
            Clock clock = new Clock();
            var parents = new Parent[2]
            {
                 new Parent('C', clock),
                new Parent('J', clock)
            };
            Scheduler scheduler = new Scheduler(inputProvider);
            Assert.AreEqual("JCCJJ", scheduler.CreateSchedule(parents, clock));
        }

        [TestMethod()]
        public void CreateSchedule4Test()
        {
            var inputProvider = new SchedulerInMemoryInputProiveder(4);
            Clock clock = new Clock();
            var parents = new Parent[2]
            {
               new Parent('C', clock),
                new Parent('J', clock)
            };
            Scheduler scheduler = new Scheduler(inputProvider);
            Assert.AreEqual("CC", scheduler.CreateSchedule(parents, clock));
        }

        [TestMethod()]
        public void CreateSchedule6Test()
        {
            var inputProvider = new SchedulerInMemoryInputProiveder(6);
            Clock clock = new Clock();
            var parents = new Parent[2]
            {
               new Parent('C', clock),
                new Parent('J', clock)
            };
            Scheduler scheduler = new Scheduler(inputProvider);
            Assert.AreEqual("CJCJCJ", scheduler.CreateSchedule(parents, clock));
        }

        [TestMethod()]
        public void CreateSchedule7Test()
        {
            var inputProvider = new SchedulerInMemoryInputProiveder(7);
            Clock clock = new Clock();
            var parents = new Parent[2]
            {
               new Parent('C', clock),
                new Parent('J', clock)
            };
            Scheduler scheduler = new Scheduler(inputProvider);
            Assert.AreEqual("CJCJCJ", scheduler.CreateSchedule(parents, clock));
        }

    }




    public class SchedulerInMemoryInputProiveder : IInputProvider
    {
        string[] currentTestCase;
        int lastLine = 0;
        string[] testCase1 = new string[]
        {
            "3",
            "360 480",
            "420 540",
            "600 660",
        };

        string[] testCase2 = new string[]
        {
            "3",
            "0 1440",
            "1 3",
            "2 4",
        };

        string[] testCase3 = new string[]
       {
            "5",
            "99 150",
            "1 100",
            "100 301",
            "2 5",
            "150 250",
       };

        string[] testCase4 = new string[]
       {
            "2",
            "0 720",
            "720 1440",
       };

        string[] testCase5 = new string[]
        {
            "5",
            /*1*/
            "3",
            "360 480",
            "420 540",
            "600 660",
            /*2*/
            "3",
            "0 1440",
            "1 3",
            "2 4",
            /*3*/
            "5",
            "99 150",
            "1 100",
            "100 301",
            "2 5",
            "150 250",
            /*4*/
            "2",
            "0 720",
            "720 1440",
            /*5*/
            "18",
            "40 50",
            "45 55",
            "50 60",
            "55 65",
            "60 70",
            "65 75",
            "0 10",
            "5 15",
            "10 20",
            "15 25",
            "20 30",
            "25 35",
            "30 40",
            "35 45",
            "70 80",
            "75 85",
            "80 90",
            "85 95",
       };

        string[] testCase6 = new string[]
    {
            "6",
            "100 200",
            "100 200",
            "0 100",
            "0 100",
            "200 300",
            "200 300",
    };

        string[] testCase7 = new string[]
{
           "18",
            "0 10",
            "5 15",
            "10 20",
            "15 25",
            "20 30",
            "25 35",
            "30 40",
            "35 45",
            "40 50",
            "45 55",
            "50 60",
            "55 65",
            "60 70",
            "65 75",
            "70 80",
            "75 85",
            "80 90",
            "85 95",
};

        public SchedulerInMemoryInputProiveder(int testCase)
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
                case 5:
                    currentTestCase = testCase5;
                    break;
                case 6:
                    currentTestCase = testCase6;
                    break;
                case 7:
                    currentTestCase = testCase7;
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