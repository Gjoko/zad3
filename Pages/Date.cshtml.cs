using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace zad3.Pages
{
    public class dateModel : PageModel
    {
        [FromQuery(Name = "time")]
        public string Time { get; set; }
        public string Title { get; set; }
        public string StringValue { get; set; }
        public void OnGet()
        {
            if (String.IsNullOrEmpty(Time)) {
                StringValue = DateTime.UtcNow.ToString("dd.MM.yyyy");
                Title = "Current Date";
            } else
            {
                StringValue = DateTime.UtcNow.ToString("dd.MM.yyyy HH:mm:ss");
                Title = "Current Date and Time";
            }
        }
    }
}
