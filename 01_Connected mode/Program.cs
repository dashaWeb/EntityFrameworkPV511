using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Connected_mode
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connection String - містить всю інформацію для підключення до сервера в певному форматі
            /* SQL Server:
                - Windows Authentication:    "Data Source=server_name;Initial Catalog=db_name;Integrated Security=True";
                - SQL Server Authentication: "Data Source=server_name;Initial Catalog=db_name;User ID=login;Password=password";
            */
            /*string conn = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=SportShop; Integrated Security=True; Connect Timeout = 2;";*/

            string conn = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            Console.WriteLine("Connected");

            // SqlCommand
            /*string cmdText = @"insert into Products
                                values('ball','Sport',50,200,'Ukraine',400)";
            SqlCommand command = new SqlCommand(cmdText, connection);
*//*            command.CommandTimeout = 5;
            command.CommandText = "";
            command.Connection = connection;*//*
            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows + " rows affected");*/


            /*string cmdText = @"select AVG(Price) from Products";
            SqlCommand command = new SqlCommand(cmdText, connection);

            var res = (int)command.ExecuteScalar();
            Console.WriteLine("Result :: " + res);*/

            string cmdText = @"select * from Products";
            SqlCommand command = new SqlCommand(cmdText, connection);

            var reader = command.ExecuteReader();

            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("\n --------------------------------");
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($"{reader.GetName(i), -15}");
            }
            Console.WriteLine();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader[i],-15}");
                }
                Console.WriteLine();
            }

            connection.Close();
        }
    }
}
