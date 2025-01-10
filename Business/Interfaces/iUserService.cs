using Business.Dtos;
using Business.Models;

namespace Business.Interfaces;

public interface iUserService
{
    bool Save(UserRegistrationForm form);
    IEnumerable<User> GetAll();
}