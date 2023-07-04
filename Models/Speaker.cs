using Microsoft.Build.Framework;

namespace SacramentMeetingPlanner.Models
{
    public class Speaker
    {
        [Required]
        public int id { get; set; }

        [Required]
        public int sacramentMeetingId { get; set; }

        [Required]
        public string name { get; set; }

        public string? topic { get; set; }
    }
}
