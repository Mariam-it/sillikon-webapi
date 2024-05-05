
using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class LearningObjectiveFactory
{
    public static LearningObjectiveViewModel Create(LearningObjectiveEntity entity)
    {
        try
        {
            return new LearningObjectiveViewModel
            {
                Id = entity.Id,
                Description = entity.Description,

            };
        }
        catch { }
        return null!;
    }
    public static IEnumerable<LearningObjectiveViewModel> Create(List<LearningObjectiveEntity> entities)
    {
        List<LearningObjectiveViewModel> learningObjectives = [];
        try
        {
            foreach (var entity in entities)
                learningObjectives.Add(Create(entity));
        }
        catch { }
        return learningObjectives;
    }
}
