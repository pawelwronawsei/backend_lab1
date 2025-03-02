using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendLab01.Pages;

public class Summary : PageModel
{
    private readonly IQuizUserService _userService;

    public Summary(IQuizUserService userService)
    {
        _userService = userService;
    }

    public int CorrectAnswersCount { get; set; }
    public int TotalQuestions { get; set; }

    public IActionResult OnGet(int quizId, int itemId)
    {
        var quiz = _userService.FindQuizById(quizId);
        if (quiz == null)
        {
            return NotFound("Quiz not found.");
        }

        int userId = 1;
        var userAnswers = _userService.GetUserAnswersForQuiz(quizId, userId);

        TotalQuestions = quiz.Items.Count;
        
        CorrectAnswersCount = userAnswers.Count(answer => answer.IsCorrect());

        return Page();
    }
}