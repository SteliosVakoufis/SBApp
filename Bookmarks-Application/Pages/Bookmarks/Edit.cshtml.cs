using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bookmarks_Application.Data;
using Bookmarks_Application.Data.Models;

namespace Bookmarks_Application.Pages.Bookmarks
{
    public class EditModel : PageModel
    {
        private readonly Bookmarks_Application.Data.AppDbContext _context;

        public EditModel(Bookmarks_Application.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bookmark Bookmark { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bookmarks == null)
            {
                return NotFound();
            }

            var bookmark =  await _context.Bookmarks.FirstOrDefaultAsync(m => m.Id == id);
            if (bookmark == null)
            {
                return NotFound();
            }
            Bookmark = bookmark;
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

            _context.Attach(Bookmark).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookmarkExists(Bookmark.Id))
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

        private bool BookmarkExists(int id)
        {
          return _context.Bookmarks.Any(e => e.Id == id);
        }
    }
}
