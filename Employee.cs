using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace Generic_Employee_Dashboard
{
    public class Employee
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public Blob Picture { get; set; }

        
        public string Adress { get; set; }

        
        public string Telephone { get; set; }

       
        public int EmergencyID { get; set; }
        
    }
}
