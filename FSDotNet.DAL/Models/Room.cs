using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDotNet.DAL.Models
{
    public class Room
    {
        [Key]
        public Guid ID { get; set; }

        public Guid RoomTypeId { get; set; }
        [ForeignKey(nameof(RoomTypeId))]

        public RoomType? RoomType { get; set; }

        public string? Location { get; set; }
        
        public double Price { get; set; }

        public bool isActive { get; set; }  


    }
}
