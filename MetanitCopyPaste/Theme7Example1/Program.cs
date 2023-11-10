using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = @"Data Source=LAPTOP-3ICN49AT\SQLEXPRESS;Initial Catalog=StripClubdb;Integrated Security=True";

        string sqlExpression = "SELECT COUNT(*) FROM Clients";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            object count = command.ExecuteScalar();

            command.CommandText = "SELECT MIN(age) FROM Clients";
            object minAge = command.ExecuteScalar();

            Console.WriteLine("В таблице {0} объектов", count);
            Console.WriteLine("Минимальный возраст: {0}", minAge);
        }


    }
}