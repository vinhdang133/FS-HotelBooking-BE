using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDotNet.DAL.Data
{
    public class HotelBookingDBContext :DbContext
    {
        public HotelBookingDBContext() { }

        public HotelBookingDBContext(DbContextOptions<HotelBookingDBContext> options) : base(options)
        {
        }
        public DbSet<Models.Room> Rooms { get; set; } = null!;
        public DbSet<Models.RoomType> RoomTypes { get; set; } = null!;
        public DbSet<Models.User> Users { get; set; } = null!;
        public DbSet<Models.Role> Roles { get; set; } = null!;
        public DbSet<Models.BookingHistory> BookingHistories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=HotelBookingDB;uid=sa;pwd=12345;TrustServerCertificate=True;MultipleActiveResultSets=True;");
        }
    }
}
