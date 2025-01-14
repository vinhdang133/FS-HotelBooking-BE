using FSDotNet.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDotNet.DAL.Contract
{
    public interface IUserRepository 
    {
        public Task<User> Create (User user);
    }
}
