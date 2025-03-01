using ApplicationCore.Commons.Repository;
using ApplicationCore.Models.QuizAggregate;
using BackendLab01;

namespace Infrastructure.Memory;
public static class SeedData
{
    public static void Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();
            
            var quizAdm = provider.GetService<IQuizAdminService>();
            
            quizAdm.AddQuizItem(points: 1, correctAnswer: "4", incorrectAnswers: new List<string>(){"5", "6", "7"}, question: "Ile to 2+2?");
            quizAdm.AddQuizItem(points: 1, correctAnswer: "10", incorrectAnswers: new List<string>(){"11", "12", "13"}, question: "Ile to 5+5?" );
            quizAdm.AddQuizItem(points: 1, correctAnswer: "20", incorrectAnswers: new List<string>(){"21", "22", "23"}, question: "Ile to 10+10?");

            var quiz = quizAdm.AddQuiz("Dodawanie", quizAdm.FindAllQuizItems());
        }
    }
}