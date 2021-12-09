using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace w8_in_class_2.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }

    }
}