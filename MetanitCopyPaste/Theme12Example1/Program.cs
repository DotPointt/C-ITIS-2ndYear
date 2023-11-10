using System.Data;
using System.Data.SqlClient;

class Program
{
    static string connectionString = @"Data Source=LAPTOP-3ICN49AT\SQLEXPRESS;Initial Catalog=StripClubdb;Integrated Security=True";
    static void Main(string[] args)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;

            try
            {
                // выполняем две отдельные команды
                command.CommandText = "INSERT INTO Clients (FIO, Age) VALUES('Tim', 34)";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO Clients (FIO, Age) VALUES('Kat', 31)";
                command.ExecuteNonQuery();

                // подтверждаем транзакцию
                transaction.Commit();
                Console.WriteLine("Данные добавлены в базу данных");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }
        }
    }

    
}
