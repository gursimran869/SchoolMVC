using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolMVC.Models
{
    public class VisitorQuery
    {

        // database connection with user name or password to validate the user name or password 
        public String txtName { get; set; }
        public String txtEmail { get; set; }
        public String txtContact { get; set; }
        public String txtMsg { get; set; }
    }
}