using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = @"Data Source=LAPTOP-3ICN49AT\SQLEXPRESS;Initial Catalog=StripClubdb;Integrated Security=True";

        string sqlExpression = "SELECT * FROM Clients";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                while (reader.Read()) // построчно считываем данные
                {
                    object id = reader.GetValue(0);
                    object status = reader.GetValue(1);
                    object FIO = reader.GetValue(2);

                    Console.WriteLine("{0}\t{1}\t{2}\t", id, status, FIO);
                }

                //ИЛИ ТАК:
                //while (reader.Read())
                //{
                //    object id = reader["id"];
                //    object name = reader["name"];
                //    object age = reader["age"];
                //    Console.WriteLine("{0} \t{1} \t{2}", id, name, age);
                //}
            }

            reader.Close();
        }

        Console.Read();
    }
}