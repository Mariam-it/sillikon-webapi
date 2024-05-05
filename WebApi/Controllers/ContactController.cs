using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Attributes;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[UseApiKey]
public class ContactController(ApiContext context) : ControllerBase
{
    private readonly ApiContext _context = context;

    [HttpPost]
    public async Task<IActionResult> Contact(ContactViewModel model)
    {
        if (ModelState.IsValid)
        {
            var contactEntity = new ContactEntity
            {
                Email = model.Email,
                Name = model.Name,
                Message = model.Message,
            };
            _context.Contacts.Add(contactEntity);
            await _context.SaveChangesAsync();
            return Ok();
        }
        return BadRequest(ModelState);
    }
}
