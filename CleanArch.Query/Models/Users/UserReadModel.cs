using CleanArch.Query.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.Models.Users
{
    public class UserReadModel : BaseReadModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Family { get; set; }
        public string Phone { get; set; }
    }
}
