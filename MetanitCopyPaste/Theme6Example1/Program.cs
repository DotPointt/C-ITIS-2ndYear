﻿using System.Data.SqlClient;

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
                    int id = reader.GetInt32(0);
                    int status = reader.GetInt32(1);
                    string FIO = reader.GetString(2);

                    Console.WriteLine("{0} \t{1} \t{2}", id, status, FIO);
                }
            }

            reader.Close();
        }

    }
}