using Npgsql;
using System;
using System.Data.SqlClient;



string connectionString = @"Data Source=LAPTOP-3ICN49AT\SQLEXPRESS;Initial Catalog=StripClubdb;Integrated Security=True";

using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();





    connection.Close();

}




class Client
{
    public int id { get; set; }
    public int status { get; set; }
    public string fio { get; set; }
    public int age { get; set; }
    public string contacts { get; set; }
    public bool IsBlocked { get; set; }
    public bool IsAnonym { get; set; }
}



