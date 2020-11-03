using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using challenge.Repositories;
using challenge.Data;

namespace challenge.Services
{
    public class ReportingService : IReportingService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<ReportingService> _logger;

        public ReportingService(ILogger<ReportingService> logger, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }
        //First search for the employee then calculate the num of reports
        public ReportingStructure search(string id)
        {
            var employee = _employeeRepository.GetById(id);
            if(employee != null){
                int numReports = calcNumOfReports(employee);
                return new ReportingStructure
                {
                    Employee = employee,
                    NumOfReports = numReports
                };
            }
           return null;
        }
        //calculates the num of direct reports recursively 
        private int calcNumOfReports(Employee employee){
        var numReports = 0;
        if(employee.DirectReports != null){
            foreach(Employee reports in  employee.DirectReports){
                numReports++;
                numReports+= calcNumOfReports(reports);
            }
        }else{
            _logger.LogDebug($"No Direct Reports found for '{employee.FirstName} {employee.LastName}'");
        }
        return numReports;
        }
    }
}