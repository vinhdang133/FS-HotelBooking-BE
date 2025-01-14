using FSDotNet.DAL.Contract;
using FSDotNet.DAL.Data;
using FSDotNet.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDotNet.DAL.Implementation
{

    public class UserRepository : IUserRepository
    {
        public Task<User> Create(User user)
        {
           HotelBookingDBContext context= new HotelBookingDBContext();
            context.Add(user);
            context.SaveChanges();
            return Task.FromResult(user);
        }
    }
}
