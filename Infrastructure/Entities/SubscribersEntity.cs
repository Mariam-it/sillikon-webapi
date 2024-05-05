
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class SubscribersEntity
{
    [Key]
    public string Email { get; set; } = null!;
    public bool DailNewsletter { get; set; }
    public bool AdvertisingUpdate { get; set; }
    public bool WeekingReview { get; set; }
    public bool EventUpdates { get; set; }
    public bool StartupWeekly { get; set; }
    public bool Podcasts { get; set; }
}
