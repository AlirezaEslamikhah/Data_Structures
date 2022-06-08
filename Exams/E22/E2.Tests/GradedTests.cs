using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TestCommon;

namespace E2.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(2000)]
        public void SolveTest_Q1ShortestPath()
        {
            RunTest(new Q1ShortestPath("TD1"));
        }
        [TestMethod(), Timeout(4000)]
        public void SolveTest_Q2ThreeChildrenMinHeap()
        {
            // Assert.Inconclusive();
            RunTest(new Q2ThreeChildrenMinHeap("TD2"));
        }

        [TestMethod(), Timeout(15000)]
        public void SolveTest_Q3HashTableAttack()
        {
            Processor p = new Q3HashTableAttack("TD3");
            TestTools.RunLocalTest("E2", p.Process, p.TestDataName, HashVerifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
            excludedTestCases: p.ExcludedTestCases);
        }
        [TestMethod(), Timeout(2000)]
        public void SolveTest_Q4MoreReading()
        {
            RunTest(new Q4MoreReading("TD4"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("E2", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
        public static void HashVerifier(string inputFileName, string testResult)
        {
            long bucketCount = long.Parse(File.ReadAllText(inputFileName));

            string[] result = testResult.Split(TestTools.IgnoreChars, StringSplitOptions.RemoveEmptyEntries);
            Assert.IsTrue(result.Length == bucketCount * 0.9);
            long bucketNumber = Q3HashTableAttack.GetBucketNumber(result[0], bucketCount);
            foreach (string str in result)
                Assert.AreEqual(bucketNumber, Q3HashTableAttack.GetBucketNumber(str, bucketCount));
        }
    }
}