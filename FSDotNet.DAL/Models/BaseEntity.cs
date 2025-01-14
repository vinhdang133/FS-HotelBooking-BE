using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDotNet.DAL.Models
{
    public class BaseEntity
    {

        public DateTime CreatOn { get; set; }

        public DateTime ModifiedOn { get; set; }

         public Guid? CreateByUser { get; set; }
        [ForeignKey(nameof(CreateByUser))]
    
        public User? User { get; set; }
        public Guid? UpdateByUser { get; set; }
        [ForeignKey(nameof(UpdateByUser))]
        public User? UpdateBy { get; set; }
    }
}
