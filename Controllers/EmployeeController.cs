using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json.Serialization;
using System.Xml;


namespace Generic_Employee_Dashboard.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepo _employeeRepo;


        public EmployeeController(EmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        
        {
            try
            {
                var employees = _employeeRepo.GetEmployees();
                
             
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
