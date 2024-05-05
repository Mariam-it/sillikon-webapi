using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Infrastructure.Entities;

public class LearningObjectiveEntity
{
    [Key]
    public int Id { get; set; }
    public string Description { get; set; } = null!;

    public int CourseId { get; set; }
    public CourseEntity Course { get; set; } = null!;
}
