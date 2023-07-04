using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Data
{
    public class SacramentMeetingPlannerContext : DbContext
    {
        public SacramentMeetingPlannerContext (DbContextOptions<SacramentMeetingPlannerContext> options)
            : base(options)
        {
        }

        public DbSet<SacramentMeetingPlanner.Models.SacramentMeeting> SacramentMeeting { get; set; } = default!;
        public DbSet<SacramentMeetingPlanner.Models.Hymn> Hymn { get; set; } = default!;
        public DbSet<SacramentMeetingPlanner.Models.Speaker> Speaker { get; set; } = default!;
    }
}
