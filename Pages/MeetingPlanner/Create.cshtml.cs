using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.MeetingPlanner
{
    public class CreateModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Data.SacramentMeetingPlannerContext _context;

        public CreateModel(SacramentMeetingPlanner.Data.SacramentMeetingPlannerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        
            ViewData["openingHymnId"] = new SelectList(_context.Hymn, "id", "display");
            ViewData["sacramentHymnId"] = new SelectList(_context.Hymn, "id", "display");
            ViewData["restHymnId"] = new SelectList(_context.Hymn, "id", "display"); 
            ViewData["closingHymnId"] = new SelectList(_context.Hymn, "id", "display");
            return Page();
        }

        [BindProperty]
        public SacramentMeeting SacramentMeeting { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.SacramentMeeting == null || SacramentMeeting == null)
            {
                return Page();
            }

            _context.SacramentMeeting.Add(SacramentMeeting);
            await _context.SaveChangesAsync();
           

            return RedirectToPage("./Index");
        }
    }
}
