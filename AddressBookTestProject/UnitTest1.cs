using AddressBookADO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AddressBookTestProject
{
    [TestClass]
    public class UnitTest1
    {
        AddressBookModel model;
        AddressBookRepo repository;

        [TestInitialize]
        public void Setup()
        {
            model = new AddressBookModel();
            repository = new AddressBookRepo();
        }
        /// <summary>
        /// Retrive All Data
        /// </summary>
        [TestMethod]
        public void TestForRetreiveAllData()
        {
            try
            {
                string actual, expected;
                expected = "Success";
                actual = repository.RetreiveAllData(model);
                Assert.AreEqual(actual, expected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
