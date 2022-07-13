using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPages_first_app.Models;

namespace RazorPages_first_app.Data
{
    public class RazorPages_first_appContext : DbContext
    {
        public RazorPages_first_appContext (DbContextOptions<RazorPages_first_appContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPages_first_app.Models.MovieModel>? MovieModel { get; set; }
    }
}
