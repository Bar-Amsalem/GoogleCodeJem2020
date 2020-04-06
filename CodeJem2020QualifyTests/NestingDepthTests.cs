using Microsoft.VisualStudio.TestTools.UnitTesting;
using CondeJem2020Qualify;
using System;
using System.Collections.Generic;
using System.Text;
using CondeJem2020Qualify.Q2;

namespace CondeJem2020Qualify.Tests
{
    [TestClass()]
    public class NestingDepthTests
    {

        [TestMethod()]
        public void SolveTest()
        {
            NestingDepth nestingDepth = new NestingDepth(new NestingDepthInMemoryInputProiveder());
            nestingDepth.Solve();
        }

        [TestMethod]
        public void StringWrapperTest()
        {
            StringWrapper wrapper = new StringWrapper();
            Assert.AreEqual("0000", wrapper.Wrap("0000"));
            Assert.AreEqual("(1)0(1)", wrapper.Wrap("101"));
            Assert.AreEqual("(111)000", wrapper.Wrap("111000"));
            Assert.AreEqual("(1)", wrapper.Wrap("1"));



            Assert.AreEqual("0((2)1)", wrapper.Wrap("021"));
            Assert.AreEqual("(((3))1(2))", wrapper.Wrap("312"));
            Assert.AreEqual("((((4))))", wrapper.Wrap("4"));
        }
    }


    public class NestingDepthInMemoryInputProiveder : IInputProvider
    {
        int lastLine = 0;
        string[] currentTestCase = new string[]
        {
            "8",
            "0000",
            "101",
            "111000",
            "1",
            "021",
            "312",
            "4",
            "009934355811100",
       };

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