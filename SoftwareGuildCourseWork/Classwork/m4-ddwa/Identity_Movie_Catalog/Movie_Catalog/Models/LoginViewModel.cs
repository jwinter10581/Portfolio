using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Query;
using System.ComponentModel.DataAnnotations;

namespace Movie_Catalog.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}