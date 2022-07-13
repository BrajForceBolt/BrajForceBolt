using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPages_first_app.Data;
using RazorPages_first_app.Models;

namespace RazorPages_first_app.Pages.Movies
{
    //[Authorize(Roles ="user")]
    public class IndexModel : PageModel
    {
        private readonly RazorPages_first_app.Data.RazorPages_first_appContext _context;

        public IndexModel(RazorPages_first_app.Data.RazorPages_first_appContext context)
        {
            _context = context;
        }

        public IList<MovieModel> MovieModel { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }
        public SelectList? Price { get; set;}

        public async Task OnGetAsync()
        {
            var movies = from m in _context.MovieModel
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString) | s.Genre.Contains(SearchString)|s.Price.ToString().Contains(SearchString)| s.ReleaseDate.ToString().Contains(SearchString));
            }

            MovieModel = await movies.ToListAsync();
        }

    }
}
