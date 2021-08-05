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
        [TestMethod]
        public void TestMethodInsertIntoTable()
        {
            try
            {
                string actual, expected;
                expected = "Success";
                model.firstName = "Ghill";
                model.lastName = "Rang";
                model.address = "Anderson Street";
                model.city = "Chennai";
                model.stateName = "Tamilnadu";
                model.zipCode = 600003;
                model.phoneNumber = 8935673227;
                model.emailId = "ikh@gmail.com";
                model.addressBookName = "Native";
                model.RelationType = "Family";
                actual = repository.InsertIntoTable(model);
                Assert.AreEqual(expected, actual);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Methods to Uodate details of a contact person
        /// </summary>
        [TestMethod]
        public void UpdateDataUsingStoredProcedure()
        {
            try
            {
                string actual, expected;
                //Setting values to model object
                model.firstName = "Mohideen";
                model.city = "Nurweliya";

                //Expected
                expected = "Success";
                actual = repository.UpdateContactDetails(model);
                Assert.AreEqual(actual, expected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
