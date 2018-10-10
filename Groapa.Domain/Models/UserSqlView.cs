using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Groapa.Domain.Models
{
    public class UserSqlView : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
