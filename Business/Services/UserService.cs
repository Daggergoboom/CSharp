using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using System.Text.Json;

namespace Business.Services;

public class UserService(iFileService fileService) : iUserService
{
    private readonly iFileService _fileService = fileService;
    private List<User> _users = [];

    public IEnumerable<User> GetAll()
    {
        var content = _fileService.GetContentFromFile();
        try
        {
            _users = JsonSerializer.Deserialize<List<User>>(content)!;
        }
        catch
        {
            _users = [];
        }

        return _users;
    }

    public bool Save(UserRegistrationForm form)
    {
        var user = UserFactory.Create(form);
        _users.Add(user);

        var json = JsonSerializer.Serialize(_users);
        var result = _fileService.SaveContentToFile(json);
        return result;
     }
}
