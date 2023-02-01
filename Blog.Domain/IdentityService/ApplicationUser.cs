using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Blog.Domain.IdentityService
{
    /// <summary>
    /// User site model
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}