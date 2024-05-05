
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class ApiContext(DbContextOptions<ApiContext> options) : DbContext(options)
{
    public DbSet<SubscribersEntity> Subscribers { get; set; }
    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<ContactEntity> Contacts { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<LearningObjectiveEntity> LearningObjective { get; set; }
    public DbSet<CourseStepsEntity> CourseSteps { get; set;}
}
