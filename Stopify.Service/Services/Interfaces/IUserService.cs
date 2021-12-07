using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopify.Service.Services.Interfaces
{
    public interface IUserService
    {
        bool Login(string userName, string password);
    }
}
