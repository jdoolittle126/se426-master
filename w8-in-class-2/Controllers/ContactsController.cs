using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using w8_in_class_2.Models;

namespace w8_in_class_2.Controllers
{
    public class ContactsController : ApiController
    {
        ContactModel[] contacts = new ContactModel[]
        {
            new ContactModel {
                Id = 1, 
                FirstName = "Bruce", 
                LastName = "Ganek", 
                PhoneNumber="508-555-1212", 
                FaxNumber= "508-555-1213", 
                EmailAddress="bruce@test.com"

            },
            new ContactModel {
                Id = 2, 
                FirstName = "Mickey", 
                LastName = "Mouse", 
                PhoneNumber="800-123-4567", 
                FaxNumber= "800-321-7654", 
                EmailAddress="mmouse@disneyworld.com"

            }
        };

        // GET: api/Contacts
        public IEnumerable<ContactModel> Get()
        {
            return contacts;
        }

        // GET: api/Contacts/5
        public ContactModel Get(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.Id == id);
            if (contact is null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return contact;
        }

        // GET: api/Contacts/Bruce
        public ContactModel Get(string firstname)
        {
            var contact = contacts.FirstOrDefault(c => c.FirstName == firstname);
            if (contact is null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return contact;
        }

        // POST: api/Contacts
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Contacts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Contacts/5
        public void Delete(int id)
        {
        }
    }
}
