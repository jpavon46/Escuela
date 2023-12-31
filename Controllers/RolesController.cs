using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Escuela.Models;
using Microsoft.AspNetCore.Identity;
using Escuela.Services;
using Microsoft.AspNetCore.Authorization;

namespace Escuela.Controllers;

public class RolesController : Controller
{

    private IRolesService _roleService;

    public RolesController(IRolesService service)
    {
        _roleService = service;
    }

    [Authorize]
    public IActionResult Index()
    {
        var users = _roleService.GetAll();
        return View(users);
    }

    [Authorize(Roles = "senior")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "senior")]
    public IActionResult Create(string roleName)
    {
        if (!string.IsNullOrEmpty(roleName)) {
            var roleExists = _roleService.roleExists(roleName);
            if (!roleExists)
            {
                _roleService.create(roleName);
            }
        }
        return RedirectToAction("Index");
    }
}