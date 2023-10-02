using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using MySql.Data.MySqlClient;

using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Tools
{
    public class WordPressDB
    {
        MySqlConnection connection;
       public bool Connected = false; 

        public WordPressDB()
        {

        }

        public void Connect()
        {
            string connectionString = "Server=localhost;Port=10017;Database=local;Uid=root;Pwd=root;";
            connection = new MySqlConnection(connectionString);
            connection.Open();
            if (connection.State==ConnectionState.Open)
            {
                Connected= true;
            }
            else
            {
                Connected= false;
            }          
        }

        public void Disconnect()
        {
           if(Connected)
            {
                connection.Close(); 
                Connected = false;
            }           
        }

        public void Get_Data(string sql )
        {
            if (Connected)
            {
                string query = "SELECT * FROM bp_data";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int Record_No = reader.GetInt32("Record_No");
                    string User_ID = reader.GetString("User_ID");
                    string DateTime = reader.GetString("DateTime");
                    string SIS = reader.GetString("SIS");
                    string DIA = reader.GetString("DIA");
                    string PUL = reader.GetString("PUL");

                    //Console.WriteLine($"Post ID: {postId}");
                    //Console.WriteLine($"Title: {postTitle}");
                    //Console.WriteLine($"Content: {postContent}");
                    //Console.WriteLine();
                }


            }
           
        }



        public bool Connect2()
        {
            string connectionString = "Server=localhost;Port=10017;Database=local;Uid=root;Pwd=root;";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM products";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int postId = reader.GetInt32("ID");
                string postTitle = reader.GetString("post_title");
                string postContent = reader.GetString("post_content");

                //Console.WriteLine($"Post ID: {postId}");
                //Console.WriteLine($"Title: {postTitle}");
                //Console.WriteLine($"Content: {postContent}");
                //Console.WriteLine();
            }

            return true;

        }
    }
}







//class Program
//{
//    static void Main()
//    {
//        string connectionString = "Server=YourServer;Port=YourPort;Database=YourDatabase;Uid=YourUsername;Pwd=YourPassword;";

//        using (MySqlConnection connection = new MySqlConnection(connectionString))
//        {
//            try
//            {
//                connection.Open();

//                // Query to retrieve data from WordPress database (e.g., posts table)
//                string query = "SELECT ID, post_title, post_content FROM wp_posts WHERE post_type = 'post'";

//                using (MySqlCommand command = new MySqlCommand(query, connection))
//                {
//                    using (MySqlDataReader reader = command.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            int postId = reader.GetInt32("ID");
//                            string postTitle = reader.GetString("post_title");
//                            string postContent = reader.GetString("post_content");

//                            Console.WriteLine($"Post ID: {postId}");
//                            Console.WriteLine($"Title: {postTitle}");
//                            Console.WriteLine($"Content: {postContent}");
//                            Console.WriteLine();
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error: " + ex.Message);
//            }
//        }
//    }
//}
////////////////////////////////////////////////////////////////////////////////////


//class Program
//{
//    static void Main()
//    {
//        string connectionString = "Server=YourServer;Port=YourPort;Database=YourDatabase;Uid=YourUsername;Pwd=YourPassword;";

//        using (MySqlConnection connection = new MySqlConnection(connectionString))
//        {
//            try
//            {
//                connection.Open();

//                // Update query
//                string updateQuery = "UPDATE YourTable SET Column1 = @NewValue1, Column2 = @NewValue2 WHERE SomeCondition";

//                using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
//                {
//                    // Replace @NewValue1, @NewValue2, and SomeCondition with appropriate values
//                    command.Parameters.AddWithValue("@NewValue1", "NewValue1");
//                    command.Parameters.AddWithValue("@NewValue2", "NewValue2");
//                    command.Parameters.AddWithValue("@SomeCondition", "ConditionValue");

//                    int rowsAffected = command.ExecuteNonQuery();

//                    Console.WriteLine($"Rows affected: {rowsAffected}");
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error: " + ex.Message);
//            }
//        }
//    }
//}
////////////////////////////////////////////////////////////////////////////////////////