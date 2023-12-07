using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text.Json.Serialization;

namespace Generic_Employee_Dashboard.EmployeeMap
{
    public class EmployeeOverview
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone {  get; set; }
        public string Email { get; set; }
        //public Blob Picture { get; set; } vet ej hur man hanterar bilder atm:)
        public int EmergnecyID { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int AdressID { get; set; }
        public string PrivatePhone { get; set; }

        

    }
}
