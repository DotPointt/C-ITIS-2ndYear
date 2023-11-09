using System.Data.SqlClient;

class Program
{
    static string connectionString = @"Data Source=LAPTOP-3ICN49AT\SQLEXPRESS;Initial Catalog=StripClubdb;Integrated Security=True";

    static void Main(string[] args)
    {
        Console.Write("Введите имя клиента:");
        string FIO = Console.ReadLine();

        Console.Write("Введите возраст клиента:");
        int age = Int32.Parse(Console.ReadLine());

        AddUser(FIO, age);
        Console.WriteLine();
        GetUsers();

        Console.Read();
    }

    // добавление пользователя
    private static void AddUser(string FIO, int age)
    {
        // название процедуры
        string sqlExpression = "sp_InsertClient";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            // указываем, что команда представляет хранимую процедуру
            command.CommandType = System.Data.CommandType.StoredProcedure;
            // параметр для ввода имени
            SqlParameter FIOParam = new SqlParameter
            {
                ParameterName = "@FIO",
                Value = FIO
            };
            // добавляем параметр
            command.Parameters.Add(FIOParam);
            // параметр для ввода возраста
            SqlParameter ageParam = new SqlParameter
            {
                ParameterName = "@age",
                Value = age
            };
            command.Parameters.Add(ageParam);

            var result = command.ExecuteScalar();
            // если нам не надо возвращать id
            //var result = command.ExecuteNonQuery();

            Console.WriteLine("Id добавленного объекта: {0}", result);
        }
    }


    // вывод всех пользователей
    private static void GetUsers()
    {
        // название процедуры
        string sqlExpression = "sp_GetClients";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            // указываем, что команда представляет хранимую процедуру
            command.CommandType = System.Data.CommandType.StoredProcedure;
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    //int age = reader.GetInt32(2);
                    object status = reader.GetValue(1);
                    //string FIO = reader.GetString(1);
                    object FIO = reader.GetValue(2);
                  
                    Console.WriteLine("{0} \t{1} \t{2}", id, status, FIO);
                }
            }
            reader.Close();
        }
    }
}