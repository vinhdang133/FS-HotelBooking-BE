using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDotNet.DAL.Models
{
    public class User : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } =null!;

        public string Email { get; set; } = null!;

        public DateTime DOB { get; set; }

        public bool Gender { get; set; }

        public string PasswordHash { get; set; } = null!;

        public Guid? RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]

        public Role? Role { get; set; }

    }
}
