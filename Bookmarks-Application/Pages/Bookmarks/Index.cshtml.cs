using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bookmarks_Application.Data;
using Bookmarks_Application.Data.Models;

namespace Bookmarks_Application.Pages.Bookmarks
{
    public class IndexModel : PageModel
    {
        private readonly Bookmarks_Application.Data.AppDbContext _context;

        public IndexModel(Bookmarks_Application.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Bookmark> Bookmark { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Bookmarks != null)
            {
                Bookmark = await _context.Bookmarks.ToListAsync();
            }
        }
    }
}
