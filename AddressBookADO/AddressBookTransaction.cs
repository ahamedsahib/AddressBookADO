using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace AddressBookADO
{
    public class AddressBookTransaction
    {
        public static string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = AddressBookService;Integrated Security=True;";


        SqlConnection connection = new SqlConnection(connectionString);
        List<AddressBookModel> addressBookModels = new List<AddressBookModel>();

        /// <summary>
        /// Add date added column
        /// </summary>
        public string AddDateColumn()
        {
            string output = string.Empty;
            using (connection)
            {
                //open the connection
                connection.Open();
                //Begin the transactions
                SqlTransaction transaction = connection.BeginTransaction();
                //Create the commit
                SqlCommand command = connection.CreateCommand();
                //Set command to transaction
                command.Transaction = transaction;

                try
                {
                    //set command text to command object
                    command.CommandText = @"ALTER TABLE Person ADD DateAdded Date";
                    //Execute command
                    command.ExecuteNonQuery();

                    //if all executes are success commit the transaction
                    transaction.Commit();
                    output = "Success";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //If any error or exception occurs rollback the transaction
                    transaction.Rollback();
                    output = "Unsuccessfull";
                }
                finally
                {
                    //close the connection
                    if (connection != null)
                        connection.Close();
                }
                return output;
            }
        }

        /// <summary>
        /// Update date added column
        /// </summary>
        public string UpdateDateCoulmn()
        {
            string output = string.Empty;
            using (connection)
            {
                //open the connection
                connection.Open();
                //Begin the transactions
                SqlTransaction transaction = connection.BeginTransaction();
                //Create the commit
                SqlCommand command = connection.CreateCommand();
                //Set command to transaction
                command.Transaction = transaction;

                try
                {
                    //set command text to command object
                    command.CommandText = @"UPDATE Person SET DateAdded='2017-05-09' WHERE PersonId=1 or PersonId=4 ";
                    //Execute command
                    command.ExecuteNonQuery();
                    //set command text to command object
                    command.CommandText = @"UPDATE Person SET DateAdded='2018-02-27' WHERE PersonId=2";
                    //Execute command
                    command.ExecuteNonQuery();
                    //set command text to command object
                    command.CommandText = @"UPDATE Person SET DateAdded='2020-03-13' WHERE PersonId=3";
                    //Execute command
                    command.ExecuteNonQuery();

                    //if all executes are success commit the transaction
                    transaction.Commit();
                    output = "Success";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //If any error or exception occurs rollback the transaction
                    transaction.Rollback();
                    output = "Unsuccessfull";
                }
                finally
                {
                    //close the connection
                    if (connection != null)
                        connection.Close();
                }
                return output;
            }
        }

        /// <summary>
        ///Retrive data based on range
        /// </summary>
        public string RetreiveDataBasedOnDateRange()
        {
            string output = string.Empty;
            using (connection)
            {
                //open the connection
                connection.Open();
                //Begin the transactions
                SqlTransaction transaction = connection.BeginTransaction();
                //Create the commit
                SqlCommand command = connection.CreateCommand();
                //Set command to transaction
                command.Transaction = transaction;

                try
                {
                    //set command text to command object
                    command.CommandText = @"SELECT ab.AddressBookId,ab.AddressBookName,p.PersonId,p.FirstName,p.LastName,p.Address,p.City,p.StateName,p.ZipCode,p.DateAdded,
                                p.PhoneNumber,p.EmailId,pt.PersonType FROM
                                AddressBook AS ab
                                INNER JOIN Person AS p ON ab.AddressBookId = p.AddressBookId AND DateAdded BETWEEN ('2015-01-01') AND GetDate()
                                INNER JOIN PersonTypesRelation as pr On pr.PersonId = p.PersonId
                                INNER JOIN PersonTypes AS pt ON pt.PersonTypeId = pr.PersonTypeId;";
                    //Execute command
                    SqlDataReader result = command.ExecuteReader();
                    //Check Result set has rows or not
                    if (result.HasRows)
                    {
                        //Parse untill  rows are null
                        while (result.Read())
                        {
                            //Print deatials that are retrived
                            PrintDetails(result);

                        }
                        output = "Success";
                    }
                    else
                    {
                        output = "Unsuccessfull";
                        transaction.Rollback();
                    }
                    //close the reader
                    result.Close();
                    //if all executes are success commit the transaction
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //If any error or exception occurs rollback the transaction
                    transaction.Rollback();
                    output = "Unsuccessfull";
                }
                finally
                {
                    //close the connection
                    if (connection != null)
                        connection.Close();
                }

            }
            return output;
        }

        /// <summary>
        /// Insert using transaction
        /// </summary>
        public string InsertUsingTransaction()
        {
            string output = string.Empty;
            using (connection)
            {
                //open the connection
                connection.Open();
                //Begin the transactions
                SqlTransaction transaction = connection.BeginTransaction();
                //Create the commit
                SqlCommand command = connection.CreateCommand();
                //Set command to transaction
                command.Transaction = transaction;

                try
                {
                    //set command text to command object
                    command.CommandText = @"INSERT INTO Person VALUES (1,'Yash','Anand','Korattur','Chennai','TN',600432,93463443210,'kgf@yash.com','2013-09-11')";
                    //Execute command
                    command.ExecuteNonQuery();
                    //set command text to command object
                    command.CommandText = @"INSERT INTO PersonTypesRelation VALUES(1,3)";
                    //Execute command
                    command.ExecuteNonQuery();


                    //if all executes are success commit the transaction
                    transaction.Commit();
                    output = "Success";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //If any error or exception occurs rollback the transaction
                    transaction.Rollback();
                    output = "Unsuccessfull";
                }
                finally
                {
                        connection.Close();
                }
                return output;
            }
        }
        /// <summary>
        /// retrieve and add multiple data to the list
        /// </summary>
        public void RetreiveAndAddMultipleDataToList()
        {
            try
            {
                string query = @"SELECT ab.AddressBookId,ab.AddressBookName,p.PersonId,p.FirstName,p.LastName,p.Address,p.City,p.StateName,p.ZipCode,p.DateAdded,
                                p.PhoneNumber,p.EmailId,pt.PersonType FROM
                                AddressBook AS ab
                                INNER JOIN Person AS p ON ab.AddressBookId = p.AddressBookId
                                INNER JOIN PersonTypesRelation as pr On pr.PersonId = p.PersonId
                                INNER JOIN PersonTypes AS pt ON pt.PersonTypeId = pr.PersonTypeId;";

                SqlCommand sqlCommand = new SqlCommand(query, this.connection);
                connection.Open();
                SqlDataReader result = sqlCommand.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        //Print deatials that are retrived
                        PrintDetails(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
        }
        /// <summary>
        /// method to retreive data and calculate Elpasedtime for retrieval  using thread
        /// </summary>
        /// <returns></returns>
        public string RetreiveDataUsingThread()
        {
            string output = string.Empty;
            try
            {
                Stopwatch stopWatch = new Stopwatch();
                //start the stopwatch
                stopWatch.Start();
                RetreiveAndAddMultipleDataToList();
                //stop stopwatch
                stopWatch.Stop();
                Console.WriteLine($"Duration : {stopWatch.ElapsedMilliseconds} milliseconds");
                output = "success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return output;
        }


        /// <summary>
        /// Print details
        /// </summary>
        public void PrintDetails(SqlDataReader result)
        {
            try 
            { 
            AddressBookModel model = new AddressBookModel();
            //reatreive data and print details
            model.addressBookId = Convert.ToInt32(result["AddressBookId"]);
            model.personId = Convert.ToInt32(result["PersonId"]);
            model.addressBookName = Convert.ToString(result["AddressBookName"]);
            model.firstName = Convert.ToString(result["FirstName"]);
            model.lastName = Convert.ToString(result["LastName"]);
            model.address = Convert.ToString(result["address"]);
            model.city = Convert.ToString(result["City"]);
            model.stateName = Convert.ToString(result["StateName"]);
            model.zipCode = Convert.ToInt32(result["ZipCode"]);
            model.phoneNumber = Convert.ToInt64(result["PhoneNumber"]);
            model.emailId = Convert.ToString(result["EmailId"]);
            model.RelationType = Convert.ToString(result["PersonType"]);
            model.DateAdded = (DateTime)result["DateAdded"];
                Thread thread = new Thread(() =>
                {
                    Console.WriteLine($"{model.addressBookId},{model.personId},{model.firstName},{model.lastName},{model.address},{model.city},{model.stateName},{model.zipCode},{model.phoneNumber},{model.emailId},{model.DateAdded},{model.addressBookName},{model.RelationType}\n");
                    addressBookModels.Add(model);
                });

                thread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
