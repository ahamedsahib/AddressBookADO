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
        AddressBookRepositoryER addressBookRepositoryER;
        AddressBookTransaction transaction;

        [TestInitialize]
        public void Setup()
        {
            model = new AddressBookModel();
            repository = new AddressBookRepo();
            addressBookRepositoryER = new AddressBookRepositoryER();
            transaction = new AddressBookTransaction();
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
       // [TestMethod]
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
        // <summary>
        /// Test method to retreive data using StateName or City
        /// </summary>
        [TestMethod]
        public void TestMethodForRetrieveUsingStateNameOrCity()
        {
            try
            {
                string actual, expected;
                expected = "Success";
                actual = repository.RetreiveDataUsingStateNameOrCityName(model);
                Assert.AreEqual(actual, expected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// Retrive All Data based on Er diagram
        /// </summary>
        [TestMethod]
        public void TestMethodForRetreiveAllDataEr()
        {
            try
            {
                string actual, expected;
                expected = "Success";
                actual = addressBookRepositoryER.RetreiveAllDataER(model);
                Assert.AreEqual(actual, expected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// Retrive All Data based on Er diagram
        /// </summary>
        [TestMethod]
        public void TestMethodForRetrieveDataUsingStateNameOrCityUsingER()
        {
            try
            {
                string actual, expected;
                expected = "Success";
                actual = addressBookRepositoryER.RetreiveAllDataStateNameOrCityER(model);
                Assert.AreEqual(actual, expected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// Sort Based on first name
        /// </summary>
        [TestMethod]
        public void TestMethodForSortByFirstNameUsingER()
        {
            try
            {
                string actual, expected;
                expected = "Success";
                actual = addressBookRepositoryER.SortDataBasedOnFirstNameER(model);
                Assert.AreEqual(actual, expected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// Add a date added field
        /// </summary>
       // [TestMethod]
        public void TestMethodForAddingDateColumn()
        {
            try
            {
                string actual, expected;
                expected = "Success";
                actual = transaction.AddDateColumn();
                Assert.AreEqual(actual, expected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// Add a date added field
        /// </summary>
        [TestMethod]
        public void TestMethodForUpdateDateAddedColumnField()
        {
            try
            {
                string actual, expected;
                expected = "Success";
                actual = transaction.UpdateDateCoulmn();
                Assert.AreEqual(actual, expected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// Retreive by date range
        /// </summary>
       [TestMethod]
        public void TestMethodForRetreiveDataByDateRange()
        {
            try
            {
                string actual, expected;
                expected = "Success";
                actual = transaction.RetreiveDataBasedOnDateRange();
                Assert.AreEqual(actual, expected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// Insert Data into table
        /// </summary>
       [TestMethod]
        public void InsertDataIntoTable()
        {
            try
            {
                string actual, expected;
                expected = "Success";
                actual = transaction.InsertUsingTransaction();
                Assert.AreEqual(actual, expected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// Test method for retreive multiple data from database 
        /// </summary>
        /// 
        [TestMethod]
        public void TestMethodForRetreiveAndAddMultipleData()
        {
            try
            {
                string actual, expected;
                expected = "success";
                actual = transaction.RetreiveDataUsingThread();
                Assert.AreEqual(actual, expected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
