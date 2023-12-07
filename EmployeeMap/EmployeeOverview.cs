using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text.Json.Serialization;

namespace Generic_Employee_Dashboard.EmployeeMap
{
    public class EmployeeOverview
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string StartDate { get; set; }

        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string PrivatePhone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string EmergencyName { get; set; }
        public string EmergencyPhoneNumber { get; set; }
        public string Relationship {  get; set; } 


        

    }
}
