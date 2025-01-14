using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDotNet.DAL.Models
{
    public class BookingHistory
    {

        [Key]
        public Guid BookingHistoryId { get; set; }
        public double TotalPrice { get; set; }

        public DateTime CheckIn {  get; set; }

        public DateTime CheckOut { get; set; }
        public  int NumberOfAdults { get; set; }

        public int NumberOfChildren {  get; set; }

        public Guid? RoomId { get; set; }
        [ForeignKey(nameof(RoomId))]
        public Room Room { get; set; }

        public Guid? UserId { get; set; }
        [ForeignKey(nameof(UserId))]

        public User?     User { get; set; }

        public DateTime PayOn { get; set; }

        public DateTime Deposition { get; set; }
    }
}
