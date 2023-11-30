using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace Generic_Employee_Dashboard.EmployeeMap
{
    public class EmployeeOverview
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
        public string Position { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Department { get; set; }
        public string StartDate { get; set; }

    }
}
