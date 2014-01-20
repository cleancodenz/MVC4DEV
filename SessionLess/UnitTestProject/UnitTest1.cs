using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;
using StubProject;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (ShimsContext.Create())
            {
                // insert the delegate that returns call for DateTime.Now
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2001, 1, 1);

                  // Create the fake calculator:
                ICalculator calculator = new StubProject.Fakes.StubICalculator();

                var math = new Mathematics(calculator);

                // Act:
                int year = math.GetTheCurrentYear();

                // Assert: 
                // This will always be true if the component is working:
                Assert.AreEqual(2001, year);
            }
        }

        [TestMethod]
        public void TestAdd()
        {

            // Create the fake calculator:
            ICalculator calculator = new StubProject.Fakes.StubICalculator()
            {
                // Define each method:
                AddDoubleDouble = (a, b) => { return 25; }
            };
            // In the completed application, item would be a real one:
            var item = new Mathematics(calculator);
            // Act:
            double added = item.AddNumbers();
            Assert.AreEqual(25, added);

        }

    }


}
