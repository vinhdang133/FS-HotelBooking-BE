using FSDotNet.DAL.Contract;
using FSDotNet.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDotNet.DAL.Implementation
{
    public class UnitOfWork : IUnitOfWork

    {

        private HotelBookingDBContext _context;

        public UnitOfWork(HotelBookingDBContext context)
        {
            _context = context;
        }
        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
