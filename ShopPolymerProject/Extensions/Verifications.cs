using DropitUI.ShopPolymerProject.Utilities;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;

namespace DropitUI.ShopPolymerProject.Extensions
{
    internal class Verifications : CommonOps
    {
        public static void VerifyEquals(int actual, int expected)
        {
            try
            {

                Assert.Equals(actual, expected);
                Console.WriteLine("Verification passed");
                extentTest.Log(LogStatus.Pass, "Verification passed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Verification failed, " + e.Message);
                string testDescription = TestContext.CurrentContext.Test.Name.Split('_')[1];
                extentTest.Log(LogStatus.Fail, "Verification failed, " + e.Message + extentTest.AddScreenCapture(ScreenShot(testDescription)));
                Assert.Fail("Verification failed, " + e.Message);

            }

        }
        public static void VerifyEquals(string actual, string expected)
        {
            try
            {

                //Assert.Equals(actual, expected);
                Assert.That(actual, Is.EqualTo(expected), "Expected and actual cart quantities are equal.");
                Console.WriteLine("Verification passed");
                extentTest.Log(LogStatus.Pass, "Verification passed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Verification failed, " + e.Message);
                string testDescription = TestContext.CurrentContext.Test.Name.Split('_')[1];
                extentTest.Log(LogStatus.Fail, "Test failed, see detailes: " + e.Message + extentTest.AddScreenCapture(ScreenShot(testDescription)));
                Assert.Fail("Verification failed, " + e.Message);

            }

        }
    }
}