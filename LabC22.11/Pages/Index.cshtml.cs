using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using LabC22._11.Data; // Убедись, что пространство имен подключено

namespace LabC22._11.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context; // Добавим контекст базы данных

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context; // Инициализируем контекст базы данных
        }

        public List<Word> Words { get; set; } // Определяем переменную Words

        public void OnGet()
        {
            Words = _context.Words.ToList();
        }
    }
}