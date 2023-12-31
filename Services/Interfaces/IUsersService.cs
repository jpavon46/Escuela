namespace Escuela.Services;
using Escuela.Models;
using Microsoft.AspNetCore.Identity;
using Escuela.Data;

public interface IUsersService
{
    List<IdentityUser> GetAll();
    Task<IdentityUser?> findId(string? id);
    UserManager<IdentityUser> getManager();
}