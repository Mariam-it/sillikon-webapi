
namespace Infrastructure.Models;

public class CourseStepsViewModel
{
    public int Id { get; set; }
    public string StepTitle { get; set; } = null!;
    public string StepDescription { get; set; } = null!;
    public string StepNumber { get; set; } = null!;
}
