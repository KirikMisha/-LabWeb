using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LabC22._11.Data;

namespace LabC22._11.Pages.List
{
    public class ListModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ListModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        [Required(ErrorMessage = "Please enter a word.")]
        public string NewWord { get; set; }

        public List<Word> Words { get; set; }

        public void OnGet()
        {
            Words = _context.Words.ToList();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var word = new Word { word = NewWord };
                _context.Words.Add(word);
                _context.SaveChanges();
                return RedirectToPage();
            }

            Words = _context.Words.ToList();
            return Page();
        }
    }
}