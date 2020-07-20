using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ngay14_7.Models.ViewModels;

namespace ngay14_7.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var listUser = await _userManager.Users.ToListAsync();
            var userRoleResponse = new List<UserRoleResponse>();
            foreach(var user in listUser)
            {
                var newUserRole = new UserRoleResponse();
                newUserRole.Roles = (List<string>)await _userManager.GetRolesAsync(user);

            }
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddRoleRequest request)
        {
            if (!ModelState.IsValid) return View(request);
            var role = new IdentityRole(request.RoleName);
            await _roleManager.CreateAsync(role);
            return View();
        }
    }
}
