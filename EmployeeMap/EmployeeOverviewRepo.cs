using Microsoft.Extensions.Options;
using System.Data.SQLite;




namespace Generic_Employee_Dashboard.EmployeeMap
{
    public class EmployeeOverviewRepo
    {
        private readonly string _connectionString;

        public EmployeeOverviewRepo(IOptions<EmployeeOverviewRepoOptions> options)
        {
            _connectionString = options.Value.ConnectionString;
        }

        public IEnumerable<EmployeeOverview> GetEmployees(string Name)
        {

            var employees = new List<EmployeeOverview>();

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                using var command = new SQLiteCommand("SELECT ID, Name, Surname, Email, Telephone, Position, " +
                "Adress, Department, StartDate FROM Employee JOIN EmployeeInfo ON Employee.ID = EmployeeInfo.EmployeeID WHERE Employee.Name = @Name", connection);
                command.Parameters.AddWithValue("Name", Name);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var employee = new EmployeeOverview()
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Surname = reader.GetString(2),
                        Email = reader.GetString(3),
                        Telephone = reader.GetString(4),
                        Position = reader.GetString(5),
                        Adress = reader.GetString(6),
                        Department = reader.GetString(7),
                        StartDate = reader.GetString(8),

                    };
                    employees.Add(employee);
                }


            }
            return employees;
        }
    }
}
