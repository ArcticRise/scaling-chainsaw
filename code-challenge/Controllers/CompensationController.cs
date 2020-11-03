using challenge.Models;
using challenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace challenge.Controllers
{
    [Route("/api/compensation/")]
    public class CompensationController : Controller
    {
        private readonly ILogger _logger;
        private readonly ICompensationService _compensationService;

        public CompensationController(ILogger<CompensationController> logger, ICompensationService compensationService)
        {
            _logger = logger;
            _compensationService = compensationService;
        }
        // Create New Compensation

        [HttpPost]
        public IActionResult CreateCompensation([FromBody] Compensation compensation)
        {
            _logger.LogDebug($"Received compensation create request for '{compensation.EmployeeId}'");

            _compensationService.Create(compensation);

            return CreatedAtRoute("getCompensationById", new { id = compensation.EmployeeId }, compensation);
        }

        //Get Compensation with provided id
        
        [HttpGet("{id}", Name = "getCompensationById")]
        public IActionResult ReadCompensation(string id)
        {
            _logger.LogDebug($"Received compensation get request for '{id}'");
            var compensation =  _compensationService.Search(id);
            if(compensation == null){
                return NotFound();
            }

            return Ok(compensation);
        }

        [HttpGet]
        public IActionResult GetAllCompensations()
        {
            _logger.LogDebug($"Received compensation get request for all employees");

            var compensations = _compensationService.GetAllCompensations();

            if (compensations == null){
                return NotFound();
            }

            return Ok(compensations);
        }

    }
}