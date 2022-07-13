using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages_first_app.Data;
using RazorPages_first_app.Models;

namespace RazorPages_first_app.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPages_first_app.Data.RazorPages_first_appContext _context;

        public DeleteModel(RazorPages_first_app.Data.RazorPages_first_appContext context)
        {
            _context = context;
        }

        [BindProperty]
      public MovieModel MovieModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MovieModel == null)
            {
                return NotFound();
            }

            var moviemodel = await _context.MovieModel.FirstOrDefaultAsync(m => m.ID == id);

            if (moviemodel == null)
            {
                return NotFound();
            }
            else 
            {
                MovieModel = moviemodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.MovieModel == null)
            {
                return NotFound();
            }
            var moviemodel = await _context.MovieModel.FindAsync(id);

            if (moviemodel != null)
            {
                MovieModel = moviemodel;
                _context.MovieModel.Remove(MovieModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
