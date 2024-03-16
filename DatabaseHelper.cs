using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static Java.Util.Jar.Attributes;

namespace ProfilePage
{
    public class DatabaseHelper
    {
        // Path to the SQLite database
        private readonly string _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "employees.db");

        public DatabaseHelper()
        {
            // Establish a connection to the database
            using var connection = new SqliteConnection($"Data Source={_dbPath}");
            connection.Open();

            // Command to create the Students table if it does not exist
            var command = connection.CreateCommand();
            command.CommandText =
            """
        CREATE TABLE IF NOT EXISTS Employee (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            FirstName TEXT NOT NULL,
            LastName TEXT NOT NULL,
            User TEXT NOT NULL,
            DateOfBirth TEXT NOT NULL,
            Password TEXT NOT NULL
        );
        """;
            command.ExecuteNonQuery(); // Execute the command
        }

        public void AddEmployee(Employee employee)
        {
            // Open a connection to the database
            using var connection = new SqliteConnection($"Data Source={_dbPath}");
            connection.Open();

            // Prepare the INSERT command
            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Employee (FirstName, LastName, User, DateOfBirth, Password) VALUES (@FirstName, @LastName, @User, @DateOfBirth, @Password)";
            // Bind parameters to avoid SQL injection
            command.Parameters.AddWithValue("@FirstName", employee.FirstName);
            command.Parameters.AddWithValue("@LastName", employee.LastName);
            command.Parameters.AddWithValue("@User", employee.User);
            command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
            command.Parameters.AddWithValue("@Password", employee.Password);
            command.ExecuteNonQuery(); // Execute the command
        }

        public Employee GetEmployee(string user)
        {
            // Open a connection to the database
            using var connection = new SqliteConnection($"Data Source={_dbPath}");
            connection.Open();

            // Prepare the SELECT command
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Employee WHERE User = @user";
            command.Parameters.AddWithValue("@user", user);

            // Execute the command and process the results
            using var reader = command.ExecuteReader();
            var employee = new Employee();
            if (reader.Read())
            {
                employee = new Employee
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    User = reader.GetString(3),
                    DateOfBirth = reader.GetString(4),
                    Password = reader.GetString(5)
                };
            }

            return employee;
        }


        public void UpdateEmployee(Employee employee)
        {
            // Open a connection to the database
            using var connection = new SqliteConnection($"Data Source={_dbPath}");
            connection.Open();

            // Prepare the UPDATE command
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE Employee SET FirstName = @FirstName, LastName = @LastName, User = @User, DateOfBirth = @DateOfBirth, Password = @Password WHERE Id = @Id";
            // Bind parameters
            command.Parameters.AddWithValue("@FirstName", employee.FirstName);
            command.Parameters.AddWithValue("@LastName", employee.LastName);
            command.Parameters.AddWithValue("@User", employee.User);
            command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
            command.Parameters.AddWithValue("@Password", employee.Password);
            command.ExecuteNonQuery(); // Execute the command
        }

        public void DeleteEmployee(int id)
        {
            // Open a connection to the database
            using var connection = new SqliteConnection($"Data Source={_dbPath}");
            connection.Open();

            // Prepare the DELETE command
            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Employee WHERE Id = @Id";
            // Bind the parameter
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery(); // Execute the command
        }
    }
}


