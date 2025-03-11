using ApplicationCore.Models.QuizAggregate;

namespace WebAPI.Dto;

public class QuizDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<QuizItemDto> Items { get; set; }

    private QuizDto()
    {
    }

    public static QuizDto of(Quiz quiz)
    {
        var quizItemDtos = new List<QuizItemDto>();

        foreach (var item in quiz.Items)
        {
            quizItemDtos.Add(QuizItemDto.of(item));
        }
        
        return new QuizDto()
        {
            Id=quiz.Id, 
            Title=quiz.Title, 
            Items=quizItemDtos
        };
    }
}