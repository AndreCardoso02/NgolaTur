using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NgolaTur.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NgolaTur.Models
{
    public class PermissoesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public PermissoesController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles;

            return View(roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = model.RoleName,
                    NormalizedName = model.RoleName
                };

                IdentityResult resultado = await roleManager.CreateAsync(role);

                if (resultado.Succeeded)
                {
                    return RedirectToAction("Index", "Permissoes");
                }

                foreach (IdentityError error in resultado.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var permissao = await roleManager.FindByIdAsync(id);

            if (permissao == null)
            {
                ViewBag.ErrorMessage = $"Não foi encontrada a permissão de id = {id}";
                return NotFound();
            }

            var model = new EditRoleViewModel
            {
                Id = permissao.Id,
                RoleName = permissao.Name
            };

            foreach (var usuario in userManager.Users)
            {
               if( await userManager.IsInRoleAsync(usuario, permissao.Name))
               {
                    model.Users.Add(usuario.UserName);
               }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditRoleViewModel model)
        {
            var permissao = await roleManager.FindByIdAsync(model.Id);

            if (permissao == null)
            {
                ViewBag.ErrorMessage = $"Não foi encontrada a permissão de id = {model.Id}";
                return NotFound();
            }
            else
            {
                permissao.Name = model.RoleName;
                permissao.NormalizedName = model.RoleName;

                var resultado = await roleManager.UpdateAsync(permissao);
            }

            return View();

        }

    }
}
