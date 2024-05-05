using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class CourseStepsFactory
{
    public static CourseStepsViewModel Create(CourseStepsEntity entity)
    {
        try
        {
            return new CourseStepsViewModel
            {
                Id = entity.Id,
                StepTitle = entity.StepTitle,
                StepDescription = entity.StepDescription,
                StepNumber = entity.StepNumber,
            };
        }
        catch { }
        return null!;
    }
    public static IEnumerable<CourseStepsViewModel> Create(List<CourseStepsEntity> entities)
    {
        List<CourseStepsViewModel> courseSteps = [];
        try
        {
            foreach (var entity in entities)
                courseSteps.Add(Create(entity));
        }
        catch { }
        return courseSteps;
    }
}
