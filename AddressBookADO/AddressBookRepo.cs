using System;
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
        public string InsertIntoTable(AddressBookModel model)
        {
            string output = string.Empty;
            try
            {
                using (connection)
                {
                    //Passing the stored procedure and connection
                    SqlCommand sqlCommand = new SqlCommand("dbo.InsertDetails",this.connection);

                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    //Adding the value
                    sqlCommand.Parameters.AddWithValue("@FirstName", model.firstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", model.lastName);
                    sqlCommand.Parameters.AddWithValue("@Address", model.address);
                    sqlCommand.Parameters.AddWithValue("@City", model.city);
                    sqlCommand.Parameters.AddWithValue("@StateName", model.stateName);
                    sqlCommand.Parameters.AddWithValue("@ZipCode", model.zipCode);
                    sqlCommand.Parameters.AddWithValue("@PhoneNum", model.phoneNumber);
                    sqlCommand.Parameters.AddWithValue("@EmailId", model.emailId);
                    sqlCommand.Parameters.AddWithValue("@AddressBookName", model.addressBookName);
                    sqlCommand.Parameters.AddWithValue("@RelationType", model.RelationType);
                    //Opening the connection
                    connection.Open();
                    //returns the number of rows updated
                    var result = sqlCommand.ExecuteNonQuery();
                    if (result != 0)
                    {
                        output = "Success";
                        Console.WriteLine("Inserted Successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Closing the connection
                connection.Close();
            }
            return output;
        }
    }
}