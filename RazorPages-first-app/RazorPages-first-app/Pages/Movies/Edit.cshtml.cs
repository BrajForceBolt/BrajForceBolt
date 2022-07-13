using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPages_first_app.Data;
using RazorPages_first_app.Models;

namespace RazorPages_first_app.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly RazorPages_first_app.Data.RazorPages_first_appContext _context;

        public EditModel(RazorPages_first_app.Data.RazorPages_first_appContext context)
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

            var moviemodel =  await _context.MovieModel.FirstOrDefaultAsync(m => m.ID == id);
            if (moviemodel == null)
            {
                return NotFound();
            }
            MovieModel = moviemodel;
            return Page();
        }

       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MovieModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieModelExists(MovieModel.ID))
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

        private bool MovieModelExists(int id)
        {
          return (_context.MovieModel?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
