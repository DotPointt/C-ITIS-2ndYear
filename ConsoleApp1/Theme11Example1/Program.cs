using System.Data;
using System.Data.SqlClient;

class Program
{
    static string connectionString = @"Data Source=LAPTOP-3ICN49AT\SQLEXPRESS;Initial Catalog=StripClubdb;Integrated Security=True";
    static void Main(string[] args)
    {
        Console.Write("Введите имя клиента:");
        string FIO = Console.ReadLine();

        GetAgeRange(FIO);

        Console.Read();
    }

    private static void GetAgeRange(string FIO)
    {
        string sqlExpression = "sp_GetAgeRange";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = CommandType.StoredProcedure; 

            SqlParameter FIOParam = new SqlParameter
            {
                ParameterName = "@FIO",
                Value = FIO
            };
            command.Parameters.Add(FIOParam);

            // определяем первый выходной параметр
            SqlParameter minAgeParam = new SqlParameter
            {
                ParameterName = "@minAge",
                SqlDbType = SqlDbType.Int // тип параметра
            };
            // указываем, что параметр будет выходным
            minAgeParam.Direction = ParameterDirection.Output;
            command.Parameters.Add(minAgeParam);

            // определяем второй выходной параметр
            SqlParameter maxAgeParam = new SqlParameter
            {
                ParameterName = "@maxAge",
                SqlDbType = SqlDbType.Int
            };
            maxAgeParam.Direction = ParameterDirection.Output;
            command.Parameters.Add(maxAgeParam);

            Console.WriteLine(command.ExecuteNonQuery());

            Console.WriteLine("Минимальный возраст: {0}", command.Parameters["@minAge"].Value);
            Console.WriteLine("Максимальный возраст: {0}", command.Parameters["@maxAge"].Value);
        }
    }
}
