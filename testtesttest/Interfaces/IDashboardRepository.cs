using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testtesttest.Models;

namespace testtesttest.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Test>> GetAllUserTests();
    }
}
