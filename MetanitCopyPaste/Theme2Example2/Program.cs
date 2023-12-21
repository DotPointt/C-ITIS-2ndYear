using System;
using System.Configuration;
using System.Data.SqlClient;


class Program
{
    static void Main(string[] args)
    {
        string connectionString = @"Data Source=LAPTOP-3ICN49AT\SQLEXPRESS;Initial Catalog=StripClubdb;Integrated Security=True";
        //string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        //SqlConnection connection = new SqlConnection(connectionString);
        //try
        //{
        //    // Открываем подключение
        //    connection.Open();
        //    Console.WriteLine("Подключение открыто в Example2");
        //}
        //catch (SqlException ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}
        //finally
        //{
        //    // закрываем подключение
        //    connection.Close();
        //    Console.WriteLine("Подключение закрыто...");
        //}


        //ИЛИ ЖЕ


        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Подключение открыто");
            Console.WriteLine("Свойства подключения:");
            Console.WriteLine("\tСтрока подключения: {0}", connection.ConnectionString);
            Console.WriteLine("\tБаза данных: {0}", connection.Database);
            Console.WriteLine("\tСервер: {0}", connection.DataSource);
            Console.WriteLine("\tВерсия сервера: {0}", connection.ServerVersion);
            Console.WriteLine("\tСостояние: {0}", connection.State);
            Console.WriteLine("\tWorkstationld: {0}", connection.WorkstationId);
        }
        Console.WriteLine("Подключение закрыто...");

        //ИЛИ ЖЕ

        //ConnectWithDB().GetAwaiter();

    }


    private static async Task ConnectWithDB()
    {
        string connectionString = @"Data Source=LAPTOP-3ICN49AT\SQLEXPRESS;Initial Catalog=StripClubdb;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();
            Console.WriteLine("Подключение открыто");
        }
        Console.WriteLine("Подключение закрыто...");
    }

}