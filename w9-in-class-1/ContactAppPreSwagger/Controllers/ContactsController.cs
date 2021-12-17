using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactAppPreSwagger.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactAppPreSwagger.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        Contact[] contacts = new Contact[]
               {
                   new Contact {ID = 1, FirstName = "Bruce", LastName = "Ganek", PhoneNumber="508-555-1212", FaxNumber= "508-555-1213", EmailAddress="bruce@test.com"},
                   new Contact {ID = 2, FirstName = "Mickey", LastName = "Mouse", PhoneNumber="800-123-4567", FaxNumber= "800-321-7654", EmailAddress="mmouse@disneyworld.com"}
               };

        //  public IEnumerable<string> Get()
        //  {
        //      return new string[] { "value1", "value2" };
        //  }
        // GET: /Contacts/GetAll
        [HttpGet]
        public Contact[] GetAll()
        {
            Contact[] contactList = new Contact[contacts.Length];

            for (int i = 0; i < contacts.Length; i++)
            {
                Contact newContact = new Contact();
                newContact = contacts[i];
                contactList[i] = newContact;
            }
            return contactList;
        }


        // GET: /Contacts/GetbyId?id=1
        [HttpGet]
        public Contact GetByID(int id)
        {
            for (int i = 0; i < contacts.Length; i++)
            {
                if (contacts[i].ID == id)
                {
                    Contact myContact = contacts[i];
                    return myContact;
                }
            }

            return null;
        }


        // GET: Contacts/GetByFirstName?firstName=Bruce
        /// <summary>
        /// MY DOC
        /// </summary>
        /// <param name="firstName">SAMPLE</param>
        /// <returns></returns>
        [HttpGet]
        public Contact GetByFirstName(string firstName)
        {
            for (int i = 0; i < contacts.Length; i++)
            {
                if (contacts[i].FirstName == firstName)
                {
                    Contact myContact = contacts[i];
                    return myContact;
                }
            }

            return null;
        }

        // POST: api/Contact
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Contact/5
        [HttpPut]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Contact/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
