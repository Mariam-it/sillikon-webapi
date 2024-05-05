using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebApi.Attributes;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[UseApiKey]
public class CoursesController(ApiContext context) : ControllerBase
{
    private readonly ApiContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll(string category = "", string searchQuery = "", int pageNumber = 1, int pageSize = 10)
    {
        try
        {
            #region query filters
            var query = _context.Courses
                .Include(c => c.CourseSteps)
                .Include(l => l.LearningObjectives)
                .Include(c => c.Category) 
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(category) && category != "all")
                query = query.Where(c => c.Category!.CategoryName == category);

            if (!string.IsNullOrWhiteSpace(searchQuery))
                query = query.Where(c => c.Title.Contains(searchQuery) || c.Author.Contains(searchQuery));

            query = query.OrderByDescending(c => c.Title);

            var courses = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            #endregion
            var response = new CourseResult
            {
                Succeeded = true,
                TotalItems = await query.CountAsync()
            };

            response.TotalPages = (int)Math.Ceiling(response.TotalItems / (double)pageSize);
            response.Courses = CourseFactory.Create(courses);

            foreach (var course in courses)
            {
                foreach (var courseStep in response.Courses)
                {
                    if (courseStep.Id == course.Id)
                    {
                        courseStep.Steps = CourseStepsFactory.Create(course.CourseSteps);
                        break;
                    }
                }
                foreach (var learning in response.Courses)
                {
                    if (learning.Id == course.Id)
                    {
                        learning.Learning = LearningObjectiveFactory.Create(course.LearningObjectives);
                        break;
                    }
                }
            }

            return Ok(response);
        }
        catch 
        {
            // Hantera undantag
            return StatusCode(500, "Ett fel uppstod när kurserna hämtades.");
        }
    }



    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        if (ModelState.IsValid)
        {
            var course = await _context.Courses
                .Include(c => c.Category) // Inkludera kategorin för kursen
                .Include(c => c.LearningObjectives)
                .Include(c => c.CourseSteps)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course != null)
                return Ok(course);

            return NotFound();
        }

        return BadRequest();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(CourseViewModel model)
    {
        if (ModelState.IsValid)
        {
            if(await _context.Courses.AllAsync(x => x.Title == model.Title))
                return Conflict();

            var course = new CourseEntity
            {
                IsBestSeller = model.IsBestSeller,
                Image = model.Image,
                Title = model.Title,
                Author = model.Author,
                Price = model.Price,
                DiscountPrice = model.DiscountPrice,
                Hours = model.Hours,
                LikesInNumber = "0",
                LikesProcent = "0",
            }; 
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return Ok();
        }
        return BadRequest();
    }


    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(int id, CourseViewModel model)
    {
        if (ModelState.IsValid)
        {
            var existingCourse = await _context.Courses.FindAsync(id);

            if (existingCourse == null)
            {
                return NotFound(); // Returnera 404 Not Found om kursen inte hittades
            }

            // Uppdatera attributen för den befintliga kursen
            existingCourse.IsBestSeller = model.IsBestSeller;
            existingCourse.Image = model.Image;
            existingCourse.Title = model.Title;
            existingCourse.Author = model.Author;
            existingCourse.Price = model.Price;
            existingCourse.DiscountPrice = model.DiscountPrice;
            existingCourse.Hours = model.Hours;

            // Sparar ändringarna till databasen
            await _context.SaveChangesAsync();

            return Ok();
        }
        return BadRequest();
    }


    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        if (ModelState.IsValid)
        {
            var courseEntity = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (courseEntity == null)
                return NotFound();

            _context.Remove(courseEntity);
            await _context.SaveChangesAsync();
            return Ok();

        }
        return BadRequest();
    }
}