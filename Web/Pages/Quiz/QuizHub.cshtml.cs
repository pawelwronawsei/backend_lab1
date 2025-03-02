using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendLab01.Pages;

public class QuizHub : PageModel
{
    private readonly IQuizAdminService _quizAdminService;

    public QuizHub(IQuizAdminService quizAdminService)
    {
        _quizAdminService = quizAdminService;
    }

    public List<ApplicationCore.Models.QuizAggregate.Quiz> QuizList { get; set; }

    public void OnGet()
    {
        QuizList = _quizAdminService.FindAllQuizzes();
    }
}