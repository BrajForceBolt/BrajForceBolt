using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPages_first_app.Data;
using RazorPages_first_app.Models;

namespace RazorPages_first_app.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly RazorPages_first_app.Data.RazorPages_first_appContext _context;

        public CreateModel(RazorPages_first_app.Data.RazorPages_first_appContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MovieModel MovieModel { get; set; } = default!;
        

        
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.MovieModel == null || MovieModel == null)
            {
                return Page();
            }

            _context.MovieModel.Add(MovieModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
           
        }

    }

}

