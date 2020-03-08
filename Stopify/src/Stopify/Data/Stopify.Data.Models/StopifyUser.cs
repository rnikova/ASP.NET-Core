using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Stopify.Data.Models
{
    public class StopifyUser : IdentityUser
    {
        public StopifyUser()
        {
        }

        public string FullName { get; set; }

        public List<Order> Orders { get; set; }
    }
}