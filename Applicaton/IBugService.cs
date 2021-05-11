using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Applicaton
{
    public interface IBugService
    {
        Task<BugDto> GetByIdAsync(int id);
    }
}
