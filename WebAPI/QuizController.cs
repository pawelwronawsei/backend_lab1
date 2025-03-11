using BackendLab01;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI;

public class QuizController : Controller
{
    private readonly IQuizUserService _service;
    
    // GET
    [Route("/api/v1/quizzes")]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    [Route("{id}")]
    public ActionResult<QuizDto> FindById(int id)
    {
        var quiz = _service.FindQuizById(id);

        var quizDto = QuizDto.of(quiz);

        if (quizDto is not null)
        {
            return Ok(quizDto);
        }
        
        return NotFound();
    } 
    
    [HttpGet]
    public IEnumerable<QuizDto> FindAll()
    {
        var quizzes = _service.FindAllQuizzes();

        var quizzesDto = new List<QuizDto>();

        foreach (var quiz in quizzes)
        {
            quizzesDto.Add(QuizDto.of(quiz));
        }

        return quizzesDto;
    }
    
    [HttpPost]
    [Route("{quizId}/items/{itemId}")]
    public void SaveAnswer([FromBody] QuizItemAnswerDto dto, int quizId, int itemId)
    {
        _service.SaveUserAnswerForQuiz(quizId, dto.UserId, itemId, dto.Answer);
    }
}