﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookADO
{
    public class AddressBookRepo
    {
        //Connection String
        public static string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = AddressBookService;Integrated Security=True;";
        //SqlConnection
       SqlConnection connection = new SqlConnection(connectionString);

        /// <summary>
        /// Method to retreive all data from retreive all data
        /// </summary>

        public string RetreiveAllData(AddressBookModel model)
        {
            string output = string.Empty;
            try
            {
                //Qurey to retreive data
                string query = "SELECT * FROM Address_Book";
                SqlCommand command = new SqlCommand(query, connection);
                //Open Connection
                this.connection.Open();
                //Returns object of result set
                SqlDataReader result = command.ExecuteReader();
                //Check Result set has rows or not
                if (result.HasRows)
                {
                    //Parse untill  rows are null
                    while (result.Read())
                    {
                        //Print deatials that are retrived
                        ShowDetails(result, model);

                    }
                    output = "Success";
                }
                else
                {
                    //Console.WriteLine("No Records in the table");
                    output = "UnSuccessfull";
                }
                //close result set
                result.Close();
            }
            catch (Exception ex)
            {
                //handle exception
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //close connection
                connection.Close();
            }
            return output;

        }

        /// <summary>
        /// Print details
        /// </summary>

        public void ShowDetails(SqlDataReader result, AddressBookModel model)
        {
            //reatreive adata and print details

            model.firstName = Convert.ToString(result["FirstName"]);
            model.lastName = Convert.ToString(result["LastName"]);
            model.address = Convert.ToString(result["address"]);
            model.city = Convert.ToString(result["City"]);
            model.stateName = Convert.ToString(result["StateName"]);
            model.zipCode = Convert.ToInt32(result["ZipCode"]);
            model.phoneNumber = Convert.ToInt64(result["Phonenum"]);
            model.emailId = Convert.ToString(result["EmailId"]);
            model.addressBookName = Convert.ToString(result["AddressBookName"]);
            model.RelationType = Convert.ToString(result["RelationType"]);

            Console.WriteLine($"{model.firstName},{model.lastName},{model.address},{model.city},{model.stateName},{model.zipCode},{model.phoneNumber},{model.emailId},{model.addressBookName},{model.RelationType}\n");
        }
    }
}