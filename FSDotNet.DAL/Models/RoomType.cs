using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDotNet.DAL.Models
{
    public class RoomType
    {
        [Key]
        public Guid RoomTypeId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public string ImageUrl { get; set; } = null!;
        public bool IsActive { get; set; }



    }
}
