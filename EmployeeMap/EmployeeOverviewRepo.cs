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

                using var command = new SQLiteCommand("SELECT " +
                    "Employee.ID, Employee.Name, Employee.Email, Employee.DateOfBirth, Employee.Gender, Employee.Telephone, Employee.PrivatePhone, " +
                    "EmployeeInfo.Position, EmployeeInfo.Department, EmployeeInfo.StartDate, " +
                    "EmergencyContacts.Name, EmergencyContacts.Telephone, EmergencyContacts.Relationship, " +
                    "Adress.Street, Adress.City, Adress.Zip, Adress.Country " +
                    "FROM Employee " +
                    "JOIN EmployeeInfo ON Employee.ID = EmployeeInfo.EmployeeID " +
                    "JOIN Adress ON Employee.AdressID = Adress.ID " +
                    "JOIN EmergencyContacts ON Employee.EmergencyID = EmergencyContacts.ID " +
                    "WHERE Employee.ID = @id", connection);
                command.Parameters.AddWithValue("id", id);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var employee = new EmployeeOverview()
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Email = reader.GetString(2),
                        DateOfBirth = reader.GetString(3),
                        Gender = reader.GetString(4),
                        Telephone = reader.GetString(5),
                        PrivatePhone = reader.GetString(6),
                        Position = reader.GetString(7),
                        Department = reader.GetString(8),
                        StartDate = reader.GetString(9),
                        EmergencyName = reader.GetString(10),
                        EmergencyPhoneNumber = reader.GetString(11),
                        Relationship = reader.GetString(12),
                        Street = reader.GetString(13),
                        City = reader.GetString(14),
                        Zip = reader.GetString(15),
                        Country = reader.GetString(16),

                    };
                    employees.Add(employee);
                }


            }
            return employees;
        }
    }
}
