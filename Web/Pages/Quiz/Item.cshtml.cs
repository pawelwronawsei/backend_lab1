using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace BackendLab01.Pages
{
    
    public class QuizModel : PageModel
    {
        private readonly IQuizUserService _userService;

        private readonly ILogger _logger;
        public QuizModel(IQuizUserService userService, ILogger<QuizModel> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        [BindProperty]
        public string Question { get; set; }
        [BindProperty]
        public List<string> Answers { get; set; }
        
        [BindProperty]
        public String UserAnswer { get; set; }
        
        [BindProperty]
        public int QuizId { get; set; }
        
        [BindProperty]
        public int ItemId { get; set; }
        
        public IActionResult OnGet(int quizId, int itemId)
        {
            QuizId = quizId;
            ItemId = itemId;

            var quiz = _userService.FindQuizById(quizId);
            if (quiz == null)
            {
                return NotFound("Taki quiz nie istnieje.");
            }
    
            if (itemId > quiz.Items.Count)
            {
                return RedirectToPage("Summary");
            }

            var quizItem = quiz.Items.ElementAtOrDefault(itemId - 1);
            if (quizItem == null)
            {
                return NotFound("Taki element nie istnieje.");
            }

            Question = quizItem.Question;
            Answers = new List<string>(quizItem.IncorrectAnswers)
            {
                quizItem.CorrectAnswer
            };

            return Page();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("Item", new {quizId = QuizId, itemId = ItemId + 1});
        }
    }
}
