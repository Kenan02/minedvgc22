using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data.SQLite;




namespace Generic_Employee_Dashboard
{
    public class EmployeeRepo
    {
        private readonly string _connectionString;

        public EmployeeRepo(IOptions<EmployeeRepoOptions> options)
        {
            _connectionString = options.Value.ConnectionString;
        }

        public IEnumerable<Employee> GetEmployees()
        {

            var employees = new List<Employee>();

            using (var connection = new SQLiteConnection(_connectionString)) 
            {
                connection.Open();

                using (var command = new SQLiteCommand("SELECT ID, Name FROM Employee", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read()) 
                    {
                        var employee = new Employee()
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        
                            

                        };
                        employees.Add(employee);
                       
                    
                    }

                }
            
            }
            return employees;
        }
    }
}
