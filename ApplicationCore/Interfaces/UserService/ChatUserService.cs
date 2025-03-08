using ApplicationCore.Commons.Repository;
using ApplicationCore.Models;

namespace BackendLab01;

public class ChatUserService : IChatUserService
{
    private readonly IGenericRepository<ChatUser, int> _repository;

    public ChatUserService(IGenericRepository<ChatUser, int> repository)
    {
        _repository = repository;
    }
    
    public void Add(string connectionId, string username)
    {
        var user = new ChatUser { ConnectionId = connectionId, Username = username };
        _repository.Add(user);
    }

    public void RemoveByName(string username)
    {
        var user = _repository.FindAll().FirstOrDefault(u => u.Username == username);
        if (user != null)
        {
            _repository.RemoveById(user.Id);
        }
    }

    public string GetConnectionIdByName(string username)
    {
        return _repository.FindAll()
            .FirstOrDefault(u => u.Username == username)?.ConnectionId;
    }

    public IEnumerable<(string ConnectionId, string Username)> GetAll()
    {
        return _repository.FindAll()
            .Select(u => (u.ConnectionId, u.Username));
    }
}