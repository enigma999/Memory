using Microsoft.Data.Sqlite;

namespace DataAcces;

public class Database
{
    private readonly string _connectionString;

    public Database(string dbPath = "/home/stan-borst/RiderProjects/Memory/mydb.db")
    {
        _connectionString = $"Data Source={dbPath}";
    }

    public void Initialize()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
            @"
            CREATE TABLE IF NOT EXISTS highscores (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                name TEXT NOT NULL,
                score INTEGER NOT NULL
            );
        ";
        command.ExecuteNonQuery();
    }

    public void AddUser(string name)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
            @"
            INSERT INTO highscores (name)
            VALUES ($name);
        ";
        command.Parameters.AddWithValue("$name", name);

        command.ExecuteNonQuery();
    }

    public void GetUsers()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT id, name FROM users;";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"{reader.GetInt32(0)}: {reader.GetString(1)}");
        }
    }
}