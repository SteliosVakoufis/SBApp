using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bookmarks_Application.Data;
using Bookmarks_Application.Data.Models;

namespace Bookmarks_Application.Pages.Bookmarks
{
    public class CreateModel : PageModel
    {
        private readonly Bookmarks_Application.Data.AppDbContext _context;

        public CreateModel(Bookmarks_Application.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Bookmark Bookmark { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bookmarks.Add(Bookmark);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
