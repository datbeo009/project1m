using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Areas.Admin.Models
{
    public class AccountModel
    {
        public int AccountID { get; set; }
      
        public string Username { get; set; }
   
        public string Password { get; set; }
     
        public string Phone { get; set; }

        public string Address { get; set; }

        public int? Gender { get; set; }

        public int? Role { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public string ConfirmPassword { get; set; }
    }
}