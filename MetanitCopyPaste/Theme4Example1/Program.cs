using System;
using System.Configuration;
using System.Data.SqlClient;


class Program
{
    static void Main(string[] args)
    {
        string connectionString = @"Data Source=LAPTOP-3ICN49AT\SQLEXPRESS;Initial Catalog=StripClubdb;Integrated Security=True";

        //using (SqlConnection connection = new SqlConnection(connectionString))
        //{
        //    connection.Open();
        //    SqlCommand command = new SqlCommand();
        //    command.CommandText = "SELECT * FROM Clients";
        //    command.Connection = connection;
        //}

        //ИЛИ С ТО ЖЕ САМОЕ С ПОМОЩЬЮ КОНСТРУКТОРА КЛАССА

        string sqlExpression = "SELECT * FROM Users";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
        }


    }

}
