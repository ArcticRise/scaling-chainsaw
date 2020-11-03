using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using challenge.Data;

namespace challenge.Repositories
{
    public class CompensationRepository : ICompensationRepository
    {
        private readonly CompensationContext _compensationContext;
        private readonly ILogger<ICompensationRepository> _logger;

        public CompensationRepository(ILogger<ICompensationRepository> logger, CompensationContext compensationContext)
        {
            _compensationContext = compensationContext;
            _logger = logger;
        }

        public Compensation Add(Compensation compensation)
        {
            _compensationContext.Compensations.Add(compensation);
            return compensation;
        }

        public Compensation GetById(string id)
        {
            var compensation = _compensationContext.Compensations.AsEnumerable().Where(e => e.EmployeeId == id);
            return compensation.SingleOrDefault();
        }

        public Task SaveAsync()
        {
            return _compensationContext.SaveChangesAsync();
        }

        public List<Compensation> GetAll()
        {
            return _compensationContext.Compensations.ToList();
        }

    }
}