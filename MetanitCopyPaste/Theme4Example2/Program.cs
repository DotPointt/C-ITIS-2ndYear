using System;
using System.Configuration;
using System.Data.SqlClient;


class Program
{
    static void Main(string[] args)
    {
        string connectionString = @"Data Source=LAPTOP-3ICN49AT\SQLEXPRESS;Initial Catalog=StripClubdb;Integrated Security=True";

        //ДОБАВЛЕНИЕ
        //string sqlExpression = "INSERT INTO Clients (id, status, age, FIO, Contacts, IsBlocked, IsAnonym) VALUES (1, 0, 15, 'Vertyanov Anton Kirillovich', '8932542345', 0, 0)";

        //ОБНОВЛЕНИЕ
        //string sqlExpression = "UPDATE Clients SET Age=19 WHERE FIO='Vertyanov Anton Kirillovich'";

        //УДАЛЕНИЕ
        string sqlExpression = "DELETE  FROM Clients WHERE FIO='Vertyanov Anton Kirillovich'";


        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
            Console.WriteLine("Добавлено/Обновлено/Удалено объектов: {0}", number);
        }


    }

}
