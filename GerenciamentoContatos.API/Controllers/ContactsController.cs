using GerenciamentoContatos.API.Models;
using GerenciamentoContatos.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace GerenciamentoContatos.API.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactDbContext _context;
        public ContactsController(ContactDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetContacts()
        {
           var contacts = _context.Contacts.ToList();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound("Contact not found.");
            }
            return Ok(contact);
        }
        [HttpPost]
        public IActionResult Post (Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetContactById), new { id = contact.Id }, contact);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Contact contact)
        {
            var existingContact = _context.Contacts.SingleOrDefault(c => c.Id == id);
            if (existingContact == null)
            {
                return NotFound("Contact not found.");
            }

            existingContact.Name = contact.Name;
            existingContact.Email = contact.Email;
            existingContact.PhoneNumber = contact.PhoneNumber;

            _context.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts.SingleOrDefault(c => c.Id == id);
            if (contact == null)
            {
                return NotFound("Contact not found.");
            }
            _context.Contacts.Remove(contact); 
            _context.SaveChanges();
            return NoContent();
        }
    }
}
