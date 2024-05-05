
using System.Text.Json.Serialization;

namespace Infrastructure.Entities;

public class CourseStepsEntity
{
    public int Id {get; set;}
    public string StepTitle { get; set; } = null!;
    public string StepDescription { get; set; } = null!;
    public string StepNumber { get; set; } = null!;

    public int CourseId { get; set; }
    public CourseEntity Course { get; set; } = null!;
}
