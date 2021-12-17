using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAppPreSwagger.Model
{
    public class Contact
    {
        [Required]
        public int ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String PhoneNumber { get; set; }
        public String FaxNumber { get; set; }
        public String EmailAddress{get; set; }
    }
}
