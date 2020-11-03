using challenge.Data;
using challenge.Models;

namespace challenge.Services
{
    //Search for my id and create a reporting struct (Interface)
    public interface IReportingService
    {
        ReportingStructure search(string id);
    }
}