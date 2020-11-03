using challenge.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace challenge.Repositories
{
    public interface ICompensationRepository
    {
        Compensation GetById(string id);
        Compensation Add(Compensation compensation);
        Task SaveAsync();
        List<Compensation> GetAll();
    }
}