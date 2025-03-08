namespace BackendLab01;

public interface IChatUserService
{
    void Add(string conncetiondId, string username);
    void RemoveByName(string username);
    string GetConnectionIdByName(string username);
    IEnumerable<(string ConnectionId, string Username)> GetAll();
}