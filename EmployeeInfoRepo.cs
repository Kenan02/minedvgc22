using Microsoft.Extensions.Options;
using System.Data.SQLite;

namespace Generic_Employee_Dashboard
{
    public class EmployeeInfoRepo
    {
        private readonly string _connectionString;

        public EmployeeInfoRepo(IOptions<EmployeeRepoOptions> options)
        {
            _connectionString = options.Value.ConnectionString;
        }

        public IEnumerable<EmployeeInfo> GetEmployeeInfo()
        {
            var employeeInfo = new List<EmployeeInfo>();

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand("SELECT * FROM EmployeeInfo"))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var employeeinfo = new EmployeeInfo()
                        {
                            EmployeeID = reader.GetInt32(0),
                            Hardware = reader.GetString(1),
                            Department = reader.GetString(2),
                            Salary = reader.GetInt32(3),
                            Position = reader.GetString(4),
                            StartDate = reader.GetDateTime(5),
                            CertificateID = reader.GetInt32(6)

                        };
                        employeeInfo.Add(employeeinfo);
                    }
                }
            }
            return employeeInfo;
        }
    }
}
