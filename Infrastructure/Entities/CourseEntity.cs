using Infrastructure.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Infrastructure.Entities;

public class CourseEntity
{
    [Key]
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
    public string LikesProcent { get; set; } = null!;
    public string LikesInNumber { get; set; } = null!;
    public string? ArticelsNumber {  get; set; } 
    public string? DownloadableResources {  get; set; }

    public int? CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }

    public List<LearningObjectiveEntity> LearningObjectives { get; set; } = [];
    public List<CourseStepsEntity> CourseSteps { get; set; } = [];
}
