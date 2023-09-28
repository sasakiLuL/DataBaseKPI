using Npgsql;

using NpgsqlConnection connection = new NpgsqlConnection();
connection.ConnectionString = "host=localhost;port=5433;database=appoi_db;user id=postgres;password=pass12345";
connection.Open();

using (var cmd = connection.CreateCommand())
{
    cmd.CommandText = "SELECT * FROM users";

    using (var reader = cmd.ExecuteReader())
    {
        while (reader.Read()) 
        {
            Console.WriteLine($"{reader["user_id"]}, {reader["first_name"]}");
        }
    }
}
