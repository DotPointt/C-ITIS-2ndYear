using System;
using System.Configuration;
using System.Data.SqlClient;


class Program
{
    static void Main(string[] args)
    {
        string connectionString = @"Data Source=LAPTOP-3ICN49AT\SQLEXPRESS;Initial Catalog=StripClubdb;Integrated Security=True";

        //SqlConnection connection;
        //connection = new SqlConnection(connectionString);

        //connection.Open();
        //Console.WriteLine(connection.ClientConnectionId);
        //connection.Close();

        //connection.Open();
        //Console.WriteLine(connection.ClientConnectionId);
        //connection.Close();


        //SECOND EXAMPLE

        
        string connectionString2 = @"Data Source=.\SQLEXPRESS;Initial Catalog=SOMECATALOG;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open(); // создается первый пул
            Console.WriteLine(connection.ClientConnectionId);
        }
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open(); // подключение извлекается из первого пула
            Console.WriteLine(connection.ClientConnectionId);
        }
        using (SqlConnection connection = new SqlConnection(connectionString2))
        {
            connection.Open(); // создается второй пул, т.к. строка подключения отличается
            Console.WriteLine(connection.ClientConnectionId);
        }

    }

}
