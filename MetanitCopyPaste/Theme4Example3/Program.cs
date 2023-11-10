using System;
using System.Configuration;
using System.Data.SqlClient;


class Program
{
    static void Main(string[] args)
    {
        string connectionString = @"Data Source=LAPTOP-3ICN49AT\SQLEXPRESS;Initial Catalog=StripClubdb;Integrated Security=True";




        Console.WriteLine("Введите ФИО:");
        string FIO = Console.ReadLine();

        Console.WriteLine("Введите возраст:");
        int age = Int32.Parse(Console.ReadLine());

        Console.WriteLine("Введите статус");
        int status = Int32.Parse(Console.ReadLine());

        Console.WriteLine("Введите контактные данные?");
        string contacts = Console.ReadLine();

        Console.WriteLine("Статус анонимности клиента 1/0?");
        int IsAnonym = Int32.Parse(Console.ReadLine());

        Console.WriteLine("Статус блокировки клиента 1/0?");
        int IsBlocked = Int32.Parse(Console.ReadLine());


        string sqlExpression = String.Format("INSERT INTO Clients (FIO, age, status, IsBlocked, IsAnonym, contacts) VALUES ('{0}', {1}, {2}, {3}, {4}, {5})", FIO, age, status, IsBlocked, IsAnonym, contacts);
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            // добавление
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
            Console.WriteLine("Добавлено объектов: {0}", number);

            // обновление ранее добавленного объекта
            Console.WriteLine("Введите новое имя:");
            FIO = Console.ReadLine();
            sqlExpression = String.Format("UPDATE Users SET Name='{0}' WHERE Age={1}", FIO, age);
            command.CommandText = sqlExpression;
            number = command.ExecuteNonQuery();
            Console.WriteLine("Обновлено объектов: {0}", number);
        }


    }

}
