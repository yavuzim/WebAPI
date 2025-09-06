using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;
using WebAPI.Dtos.ContactDtos;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly APIContext context;
        public ContactsController(APIContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = context.Contacts.ToList();
            return Ok(values);
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = context.Contacts.Find(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact()
            {
                MapLocation = createContactDto.MapLocation,
                Address = createContactDto.Address,
                Phone = createContactDto.Phone,
                Email = createContactDto.Email,
                OpenHours = createContactDto.OpenHours
            };
            context.Contacts.Add(contact);
            context.SaveChanges();
            return Ok("Contact added successfully.");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact contact = new Contact()
            {
                ContactId = updateContactDto.ContactId,
                MapLocation = updateContactDto.MapLocation,
                Address = updateContactDto.Address,
                Phone = updateContactDto.Phone,
                Email = updateContactDto.Email,
                OpenHours = updateContactDto.OpenHours
            };
            context.Contacts.Update(contact);
            context.SaveChanges();
            return Ok("Contact updated successfully.");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = context.Contacts.Find(id);
            context.Contacts.Remove(value);
            context.SaveChanges();
            return Ok("Contact deleted successfully.");
        }
    }
}
