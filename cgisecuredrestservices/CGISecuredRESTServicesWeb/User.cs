using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGISecuredRESTServicesWeb
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return string.Format(@"{0}, {1}, {2}",
                this.UserName, this.Password, this.Email);
        }
    }
}
