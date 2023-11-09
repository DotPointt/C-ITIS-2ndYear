using System.Data.SqlClient;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = @"Data Source=LAPTOP-3ICN49AT\SQLEXPRESS;Initial Catalog=StripClubdb;Integrated Security=True";

        int age = 46;
        string FIO = "Tom',10);INSERT INTO Clients (SOME TRASH, Age) VALUES('Hack";

        string sqlExpression = "INSERT INTO Clients (FIO, age) VALUES (@FIO, @age)";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            // создаем параметр для имени
            SqlParameter nameParam = new SqlParameter("@FIO", FIO);
            // добавляем параметр к команде
            command.Parameters.Add(nameParam);
            // создаем параметр для возраста
            SqlParameter ageParam = new SqlParameter("@age", age);
            // добавляем параметр к команде
            command.Parameters.Add(ageParam);

            int number = command.ExecuteNonQuery();
            Console.WriteLine("Добавлено объектов: {0}", number); // 1
        }


    }
}