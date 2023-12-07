using Generic_Employee_Dashboard.EmployeeMap;
using Microsoft.AspNetCore.Mvc;


namespace Generic_Employee_Dashboard.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeOverviewController : ControllerBase
    {
        private readonly EmployeeOverviewRepo _employeeOverviewRepo;



        public EmployeeOverviewController(EmployeeOverviewRepo employeeRepo)
        {
            _employeeOverviewRepo = employeeRepo;
        }


        [HttpGet("{id}")]
        public ActionResult<IEnumerable<EmployeeOverview>> GetEmployees(int id)

        {
            try
            {
                var employees = _employeeOverviewRepo.GetEmployees(id);

                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
