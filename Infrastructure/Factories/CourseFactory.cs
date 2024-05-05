using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class CourseFactory
{
    public static CourseViewModel Create(CourseEntity entity)
    {
        try
        {

            return new CourseViewModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Author = entity.Author,
                Price = entity.Price,
                DiscountPrice = entity.DiscountPrice,
                Hours = entity.Hours,
                LikesInNumber = entity.LikesInNumber,
                LikesProcent = entity.LikesProcent,
                Image = entity.Image,
                IsBestSeller = entity.IsBestSeller,
                Category = entity.Category!.CategoryName,

            };
        }
        catch { }
        return null!;
    }
    public static IEnumerable<CourseViewModel> Create(List<CourseEntity> entities)
    {
        List<CourseViewModel> courses = [];
        try
        {
            foreach (var entity in entities)
                courses.Add(Create(entity));
        }
        catch { }
        return courses;
    }
}
