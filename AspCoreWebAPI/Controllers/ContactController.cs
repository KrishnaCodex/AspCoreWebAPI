using AspCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private List<Contact> contacts = new List<Contact>()
        {
            new Contact {id = 1, FirstName ="Peter", LastName = "Parker", NickName ="SpiderMan", Place ="NewYork City" },
            new Contact {id = 2, FirstName ="Tony", LastName = "Stark", NickName ="IronMan", Place ="Los Angeles" }
        };
        // GET: api/<ContactController>
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return contacts;
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            return contacts.FirstOrDefault(c => c.id == id);
        }

        // POST api/<ContactController>
        [HttpPost]
        public ActionResult<IEnumerable<Contact>>Post(Contact newcontact)
        {
            contacts.Add(newcontact);
            return contacts;
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Contact>> Put(int id, Contact updatedcontact)
        {
            Contact contact = contacts.FirstOrDefault(c => c.id == id);
            if (contact == null)
            {
                return NotFound();
            }
            contact.NickName = updatedcontact.NickName;
            contact.IsDeleted = updatedcontact.IsDeleted;
            return contacts;
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Contact>> Delete(int id)
        {
            Contact contact = contacts.FirstOrDefault(c => c.id == id);
            if (contact == null)
            {
                return NotFound();
            }
            contacts.Remove(contact);
            return contacts;
        }
    }
}
