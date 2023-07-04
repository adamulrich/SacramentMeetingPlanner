using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.MeetingPlanner
{
    public class IndexModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Data.SacramentMeetingPlannerContext _context;

        public IndexModel(SacramentMeetingPlanner.Data.SacramentMeetingPlannerContext context)
        {
            _context = context;
        }

        public IList<SacramentMeeting> SacramentMeeting { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SacramentMeeting != null)
            {
                SacramentMeeting = await _context.SacramentMeeting
                .Include(s => s.closingHymn)
                .Include(s => s.openingHymn)
                .Include(s => s.restHymn)
                .Include(s => s.sacramentHymn).ToListAsync();
            }
        }
    }
}
