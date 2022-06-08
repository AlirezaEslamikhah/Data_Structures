using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TestCommon;
using A2;
using System.Diagnostics;
namespace A2.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod()]
        public void SolveTest_Q1NaiveMaxPairWise()
        {
            RunTest(new Q1NaiveMaxPairWise("TD1"));
        }

        [TestMethod(), Timeout(1500)]
        public void SolveTest_Q2FastMaxPairWise()
        {
            RunTest(new Q2FastMaxPairWise("TD2"));
        }

        [TestMethod()]
        public void SolveTest_StressTest()
        {
            Q1NaiveMaxPairWise class1 = new Q1NaiveMaxPairWise("");
            Q2FastMaxPairWise class2 = new Q2FastMaxPairWise("");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while(timer.Elapsed.TotalSeconds<5)
            {
                Random rd = new Random();
                int size = rd.Next(2,100);
                long[] a = new long[size];
                for (int i = 0; i < size; i++)
                {
                    a[i] = rd.Next(0,1000);
                }
                long res1 = class1.Solve(a);
                long res2 = class2.Solve(a);
                if (res1!=res2)
                {
                    System.Console.WriteLine(a.ToString());
                }
            }
            timer.Stop();
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A2", p.Process, p.TestDataName, p.Verifier);
        }

    }
}