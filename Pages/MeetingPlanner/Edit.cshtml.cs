using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.MeetingPlanner
{
    public class EditModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Data.SacramentMeetingPlannerContext _context;

        public EditModel(SacramentMeetingPlanner.Data.SacramentMeetingPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SacramentMeeting SacramentMeeting { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SacramentMeeting == null)
            {
                return NotFound();
            }

            var sacramentmeeting =  await _context.SacramentMeeting.FirstOrDefaultAsync(m => m.sacramentMeetingId == id);
            if (sacramentmeeting == null)
            {
                return NotFound();
            }
            SacramentMeeting = sacramentmeeting;
           ViewData["closingHymnId"] = new SelectList(_context.Hymn, "id", "id");
           ViewData["openingHymnId"] = new SelectList(_context.Hymn, "id", "id");
           ViewData["restHymnId"] = new SelectList(_context.Hymn, "id", "id");
           ViewData["sacramentHymnId"] = new SelectList(_context.Hymn, "id", "id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SacramentMeeting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SacramentMeetingExists(SacramentMeeting.sacramentMeetingId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SacramentMeetingExists(int id)
        {
          return (_context.SacramentMeeting?.Any(e => e.sacramentMeetingId == id)).GetValueOrDefault();
        }
    }
}
