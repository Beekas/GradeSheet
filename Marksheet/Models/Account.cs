using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marksheet.Models
{
    public class Account
    {
        public int Id { get; set; }
       
        public string FullName { get; set; }
        
        public string Email { get; set; }

        public string UserName { get; set; }
       
        public string Password { get; set; }

        public string Phone { get; set; }
      
        public string Category { get; set; }

        public string WorkPhone { get; set; }
        public string URL { get; set; }

        public string PPSizePhoto { get; set; }

        public bool Status { get; set; }
      
        public DateTime CreatedDate { get; set; }
       
        public DateTime ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public string randompass { get; set; }

    }
}