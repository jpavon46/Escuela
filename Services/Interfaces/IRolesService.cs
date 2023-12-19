namespace Escuela.Services;
using Escuela.Models;
using Microsoft.AspNetCore.Identity;

public interface IRolesService
{
    List<IdentityRole> GetAll();
    bool roleExists(string roleName);
    void create(string roleName);

}