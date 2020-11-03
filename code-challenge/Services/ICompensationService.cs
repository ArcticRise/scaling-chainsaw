using challenge.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Services
{
    public interface ICompensationService
    {
        Compensation Create(Compensation compensation);
        Compensation Search(string id);
        List<Compensation> GetAllCompensations();

    }
}