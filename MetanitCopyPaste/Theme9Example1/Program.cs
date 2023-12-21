using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = @"Data Source=LAPTOP-3ICN49AT\SQLEXPRESS;Initial Catalog=StripClubdb;Integrated Security=True";

        int age = 46;
        string FIO = "Zubenko Mihail Petrovich";

        string sqlExpression = "INSERT INTO Clients (FIO, age) VALUES (@FIO, @age);SET @id=SCOPE_IDENTITY()";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            // создаем параметр для имени
            SqlParameter FIOParam = new SqlParameter("@FIO", FIO);
            // добавляем параметр к команде
            command.Parameters.Add(FIOParam);
            // создаем параметр для возраста
            SqlParameter ageParam = new SqlParameter("@age", age);
            // добавляем параметр к команде
            command.Parameters.Add(ageParam);
            // параметр для id
            SqlParameter idParam = new SqlParameter
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output // параметр выходной
            };
            command.Parameters.Add(idParam);

            command.ExecuteNonQuery();

            // получим значения выходного параметра
            Console.WriteLine("Id нового объекта: {0}", idParam.Value);
        }


    }
}