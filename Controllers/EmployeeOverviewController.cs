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


        [HttpGet]
        public ActionResult<IEnumerable<EmployeeOverview>> GetEmployees()

        {

            try
            {
                var employees = _employeeOverviewRepo.GetEmployees(1);

                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
