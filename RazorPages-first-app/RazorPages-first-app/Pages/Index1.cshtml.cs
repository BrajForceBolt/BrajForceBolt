using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;

namespace RazorPages_first_app.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; private set; } = "PageModel in C#";

        public void OnGet()
        {
            Message += $" Server time is {DateTime.Now}";

        }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public Gender StudentGender { get; set; }
    }
    public enum Gender
    {
        Male,
        Female,
    }
    

}