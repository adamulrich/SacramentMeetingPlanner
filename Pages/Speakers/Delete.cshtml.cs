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
    public class DeleteModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Data.SacramentMeetingPlannerContext _context;

        public DeleteModel(SacramentMeetingPlanner.Data.SacramentMeetingPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Speaker Speaker { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Speaker == null)
            {
                return NotFound();
            }

            var speaker = await _context.Speaker.FirstOrDefaultAsync(m => m.id == id);

            if (speaker == null)
            {
                return NotFound();
            }
            else 
            {
                Speaker = speaker;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Speaker == null)
            {
                return NotFound();
            }
            var speaker = await _context.Speaker.FindAsync(id);

            if (speaker != null)
            {
                Speaker = speaker;
                _context.Speaker.Remove(Speaker);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
