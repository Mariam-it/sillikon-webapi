
namespace Infrastructure.Models;

public class CourseViewModel
{
    public int Id { get; set; }
    public bool IsBestSeller { get; set; }
    public string Image { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string DescriptionTitle { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string Price { get; set; } = null!;
    public string? DiscountPrice { get; set; }
    public string Hours { get; set; } = null!;
    public string? LikesProcent { get; set; }
    public string? LikesInNumber { get; set; }
    public string? ArticelsNumber { get; set; }
    public string? DownloadableResources { get; set; }
    public string Category { get; set; } = null!;

    public IEnumerable<LearningObjectiveViewModel>? Learning { get; set; }
    public IEnumerable<CourseStepsViewModel>? Steps { get; set; }
}
