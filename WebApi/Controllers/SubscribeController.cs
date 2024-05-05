using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Attributes;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[UseApiKey]
public class SubscribeController(ApiContext context) : ControllerBase
{
    private readonly ApiContext _context = context;

    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscribersEntity entity)
    {
        if (ModelState.IsValid)
        {
            if(await _context.Subscribers.AnyAsync(x => x.Email == entity.Email))
                return Conflict();

            _context.Add(entity);
            await _context.SaveChangesAsync();
            return Ok();

        }
        return BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> Unsubscribe(string email)
    {
        if (ModelState.IsValid)
        {
            var subscriberEntity = await _context.Subscribers.FirstOrDefaultAsync(x => x.Email == email);
            if (subscriberEntity == null)
                return NotFound();

            _context.Remove(subscriberEntity);
            await _context.SaveChangesAsync();
            return Ok();

        }
        return BadRequest();
    }
}
