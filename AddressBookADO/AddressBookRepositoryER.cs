using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookADO
{
    public class AddressBookRepositoryER
    {
        public static string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = AddressBookService;Integrated Security=True;";

        //SqlConnection
        SqlConnection connection = new SqlConnection(connectionString);

        /// <summary>
        /// Method to retreive all data Accorting to  er diagram
        /// </summary>
       
        public string RetreiveAllDataER(AddressBookModel model)
        {
            string output = string.Empty;
            try
            {
                //Qurey to retreive data
                string query = @"SELECT ab.AddressBookId,ab.AddressBookName,p.PersonId,p.FirstName,p.LastName,p.Address,p.City,p.StateName,p.ZipCode,
                                p.PhoneNumber,p.EmailId,pt.PersonType FROM
                                AddressBook AS ab
                                INNER JOIN Person AS p ON ab.AddressBookId = p.AddressBookId
                                INNER JOIN PersonTypesRelation as pr On pr.PersonId = p.PersonId
                                INNER JOIN PersonTypes AS pt ON pt.PersonTypeId = pr.PersonTypeId; ";
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
                    output = "Success";
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
        /// Method to retreive all data from er diagram
        /// </summary>
        public string RetreiveAllDataStateNameOrCityER(AddressBookModel model)
        {
            string output = string.Empty;
            try
            {
                //Qurey to retreive data
                string query = @"SELECT ab.AddressBookId,ab.AddressBookName,p.PersonId,p.FirstName,p.LastName,p.Address,p.City,p.StateName,p.ZipCode,
                                p.PhoneNumber,p.EmailId,pt.PersonType,pt.PersonTypeId FROM
                                AddressBook AS ab 
                                INNER JOIN Person AS p ON ab.AddressBookId = p.AddressBookId AND (p.City='chennai' OR p.StateName='TN')
                                INNER JOIN PersonTypesRelation as pr On pr.PersonId = p.PersonId
                                INNER JOIN PersonTypes AS pt ON pt.PersonTypeId = pr.PersonTypeId; ";
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
                    output = "Success";
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
        /// Retrive data based on state name or city name er diagram
        /// </summary>
        public string SortDataBasedOnFirstNameER(AddressBookModel model)
        {
            string output = string.Empty;
            try
            {
                using (this.connection)
                {
                    string query = @"SELECT ab.AddressBookId,ab.AddressBookName,p.PersonId,p.FirstName,p.LastName,p.Address,p.City,p.StateName,p.ZipCode,
                                    p.PhoneNumber,p.EmailId,pt.PersonType,pt.PersonTypeId FROM
                                    AddressBook AS ab 
                                    INNER JOIN Person AS p ON ab.AddressBookId = p.AddressBookId
                                    INNER JOIN PersonTypesRelation as pr On pr.PersonId = p.PersonId
                                    INNER JOIN PersonTypes AS pt ON pt.PersonTypeId = pr.PersonTypeId ORDER BY p.FirstName ;";
                    SqlCommand command = new SqlCommand(query, connection);
                    //Open Connection
                    this.connection.Open();
                    //Returns object of result set
                    SqlDataReader result = command.ExecuteReader();

                    //checking result set has rows are not
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            //Print deatials that are retrived
                            ShowDetails(result, model);
                        }
                        //close the reader object
                        result.Close();
                    }
                    output = "Success";
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                output = "Unsuccessfull";
            }
            finally
            {
                //close the connection
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
            model.addressBookId = Convert.ToInt32(result["AddressBookId"]);
            model.personId = Convert.ToInt32(result["PersonId"]);
            model.addressBookName = Convert.ToString(result["AddressBookName"]);
            model.firstName = Convert.ToString(result["FirstName"]);
            model.lastName = Convert.ToString(result["LastName"]);
            model.address = Convert.ToString(result["Address"]);
            model.city = Convert.ToString(result["City"]);
            model.stateName = Convert.ToString(result["StateName"]);
            model.zipCode = Convert.ToInt32(result["ZipCode"]);
            model.phoneNumber = Convert.ToInt64(result["PhoneNumber"]);
            model.emailId = Convert.ToString(result["EmailId"]);
            model.RelationType = Convert.ToString(result["PersonType"]);

            Console.WriteLine($"{model.addressBookId},{model.personId},{model.firstName},{model.lastName},{model.address},{model.city},{model.stateName},{model.zipCode},{model.phoneNumber},{model.emailId},{model.addressBookName},{model.RelationType}\n");
        }
    }
}
