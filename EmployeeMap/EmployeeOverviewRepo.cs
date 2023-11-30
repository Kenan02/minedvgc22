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

        public IEnumerable<EmployeeOverview> GetEmployees(int id)
        {

            var employees = new List<EmployeeOverview>();

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                using var command = new SQLiteCommand("SELECT ID, Name, Email, Telephone, Position, " +
                "Adress, Department, StartDate FROM Employee JOIN EmployeeInfo ON Employee.ID = EmployeeInfo.EmployeeID WHERE Employee.ID = @id", connection);
                command.Parameters.AddWithValue("id", id);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var employee = new EmployeeOverview()
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Email = reader.GetString(2),
                        Telephone = reader.GetString(3),
                        Position = reader.GetString(4),
                        Adress = reader.GetString(5),
                        Department = reader.GetString(6),
                        StartDate = reader.GetString(7),

                    };
                    employees.Add(employee);
                }


            }
            return employees;
        }
    }
}
