using System;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace miniproject // Note: actual namespace depends on the project name.
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection;
            string connectionString = @"Data Source=.;Initial Catalog=MProject;Integrated Security=True";
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection estabished successfully");

                //crud

                //insert
                Console.WriteLine("Enter your name");
                string userName = Console.ReadLine();

                Console.WriteLine("Enter your age");
                int userAge = int.Parse(Console.ReadLine());
                string insertQuery = "INSERT INTO DETAILS(user_name, user_age) VALUES ('" + userName + "'," + userAge + ")";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                insertCommand.ExecuteNonQuery();
                Console.WriteLine("Data is successfully inserted");
                //Retrieve=> R

                //Display

                string displayQuery = "SELECT * FROM Details";
                SqlCommand displayCommand = new SqlCommand(displayQuery, sqlConnection);
                SqlDataReader dataReader= displayCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine("Id: "+ dataReader.GetValue(0).ToString());
                    Console.WriteLine("Name: " + dataReader.GetValue(1).ToString());
                    Console.WriteLine("Age: " + dataReader.GetValue(2).ToString());

                }
                dataReader.Close();

                //update
                int u_id;
                int u_age;
                Console.WriteLine("Enter the user id that you would like to update");
                u_id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the age the user to you would like to update");
                u_age = int.Parse(Console.ReadLine());
                string updateQuery = "UPDATE Details SET user_age = " + u_age  + "WHERE user_id = " + u_id + "";
                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
                updateCommand.ExecuteNonQuery();
                Console.WriteLine("Data Successfully Updated");

                //delete
                int d_id;
                Console.WriteLine("Enter the id of record  that you would like tobe delete");
                d_id = int.Parse(Console.ReadLine());
                string deleteQuery = "DELETE FROM Details WHERE user_id = " + d_id;
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
                deleteCommand.ExecuteNonQuery();
                Console.WriteLine("Delated successfully");
                sqlConnection.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}