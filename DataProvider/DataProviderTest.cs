using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DataProviderLibrary
{
    
    
    /// <summary>
    ///This is a test class for DataProviderTest and is intended
    ///to contain all DataProviderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DataProviderTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetStationList
        ///</summary>
        [TestMethod()]
        public void GetStationListTest()
        {
            IList<Station> actual = new DataProvider().GetStationList();
            Assert.AreEqual(5, actual.Count, "we should have 5 records");
            
        }

        /// <summary>
        ///A test for GetYearList
        ///</summary>
        [TestMethod()]
        public void GetYearListTest()
        {
            var actual = new DataProvider().GetYearList();
            Assert.AreEqual(5, actual.Count);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void GetFeedBackListTest()
        {
            var actual = new DataProvider().GetFeedBackList();
            Assert.AreEqual(25, actual.Count, "we should have 25 records");
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
        
    }
}
