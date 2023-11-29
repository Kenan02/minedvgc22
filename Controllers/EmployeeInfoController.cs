using Microsoft.AspNetCore.Mvc;

namespace Generic_Employee_Dashboard.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeInfoController : ControllerBase
    {
        public readonly EmployeeInfoRepo _employeeInfoRepo;

        public EmployeeInfoController(EmployeeInfoRepo employeeInfoRepo)
        {
            _employeeInfoRepo = employeeInfoRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeInfo>> GetEmployeeInfo()

        {
            try
            {
                var employeeInfo = _employeeInfoRepo.GetEmployeeInfo();


                return Ok(employeeInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
