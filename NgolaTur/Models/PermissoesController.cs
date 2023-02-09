using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NgolaTur.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NgolaTur.Models
{
    [Authorize(Roles = "Admin")]
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

                if (resultado.Succeeded)
                {
                    return RedirectToAction("Index", "Permissoes");
                }

                foreach (IdentityError error in resultado.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var permissao = await roleManager.FindByIdAsync(roleId);

            if (permissao == null)
            {
                ViewBag.ErrorMessage = $"Permissão de Id = {roleId} não encontrada";
                return NotFound();
            }

            var model = new List<UserRoleViewModel>();

            foreach (var user in userManager.Users)
            {
                var userViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                };

                if (await userManager.IsInRoleAsync(user, permissao.Name))
                {
                    userViewModel.IsSelected = true;
                }
                else
                {
                    userViewModel.IsSelected = false;
                }

                model.Add(userViewModel);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {
            var permissao = await roleManager.FindByIdAsync(roleId);

            if (permissao == null)
            {
                ViewBag.ErrorMessage = $"Não foi encontrada a permissão de id = {roleId}";
                return NotFound();
            }

            for (int i = 0; i < model.Count; i++)
            {
                var usuario = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult resultado = null;

                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(usuario, permissao.Name)))
                {
                    resultado =await userManager.AddToRoleAsync(usuario, permissao.Name);
                }
                else if (!model[i].IsSelected && (await userManager.IsInRoleAsync(usuario, permissao.Name)))
                {
                    if (!usuario.UserName.Equals("root@root.com") && !usuario.Email.Equals("root@root.com"))
                        resultado = await userManager.RemoveFromRoleAsync(usuario, permissao.Name);
                }
                else
                {
                    continue;
                }

                if (resultado.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("Edit", new { Id = roleId });
                }
            }

            return RedirectToAction("Edit", new { Id = roleId });
        }
    }
}
