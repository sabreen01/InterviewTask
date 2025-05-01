using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Models
{
    public class User : IdentityUser<int>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }

    public class UserRole : IdentityUserRole<int>
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }

    public class Role : IdentityRole<int>
    {
    }
}