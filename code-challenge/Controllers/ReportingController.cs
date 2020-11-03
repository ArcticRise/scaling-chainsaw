using System.Threading.Tasks;
using challenge.Data;
using challenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace challenge.Controllers
{
    [Route("/api/reportingStructure/")]
    public class ReportingController : Controller
    {
        private readonly ILogger _logger;
        private readonly IReportingService _reportingService;
        public ReportingController(ILogger<ReportingController> logger, IReportingService reportingService)
        {
            _logger = logger;
            _reportingService = reportingService;
        }

    //Get Reporting Structure for the given id

    [HttpGet("{id}", Name = "read")]
    public IActionResult Read(string id){
        _logger.LogDebug($"Recieved reporting get request for '{id}'");
        var reportingStruct =  _reportingService.search(id);
        if(reportingStruct == null){
            return NotFound();
        }

        return Ok(reportingStruct);
    }
        
    }
}