using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;


namespace SacramentMeetingPlanner.Pages.Speakers
{
    public class IndexModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Data.SacramentMeetingPlannerContext _context;

        public IndexModel(SacramentMeetingPlanner.Data.SacramentMeetingPlannerContext context)
        {
            _context = context;
        }

        public IList<Speaker> Speaker { get;set; } = default!;

        public async Task OnGetAsync(int id)
        {
            if (id > 0)
            {

                if (_context.Speaker != null)
                {
                    Speaker = await _context.Speaker.Where(s => s.sacramentMeetingId == id).ToListAsync();
                }
            }
        }
    }
}
