using IdentityModel;
using IdentitySerrver4.Models;
using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentitySerrver4.Quickstart.Admin
{
    //[Authorize(Roles ="Admin")]
    [Route("Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        

        public AdminController(
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public  IActionResult Admin()
        {
            return View();
        }

        [HttpGet]
        [Route("AccessDenid")]
        [AllowAnonymous]
        public IActionResult AccessDenid()
        {
            return View();
        }

        #region USERS

        [HttpGet]
        [Route("ListUsers")]
        public IActionResult ListUsers()
        {
            var u = HttpContext.User.Claims;
            var users = _userManager.Users.ToList();
            return View(users);
        }
        [HttpGet]
        [Route("EditUser")]
        public async Task<IActionResult> EditUser(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {Id} not fount";
                return View("NotFound");
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            var userClaims = await _userManager.GetClaimsAsync(user);
            var model = new EditUserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                phoneNumber = user.PhoneNumber,
                Claims = userClaims.Select(c => c.Value).ToList(),
                Roles = userRoles
            };
            return View(model);
        }
        [HttpPost]
        [Route("EditUser")]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} not fount";
                return View("NotFound");
            }
            else
            {
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.PhoneNumber = model.phoneNumber;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {Id} not fount";
                return View("Error/NotFound");
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("ListUsers");
            }

        }
        [HttpGet]
        [Route("ManageUserRoles")]
        public async Task<IActionResult> ManageUserRoles(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"user with Id = {Id} not fount";
                return View("Error/NotFound");
            }
            var model = new List<EditRolesInUser>();
            foreach (var role in _roleManager.Roles)
            {
                model.Add(new EditRolesInUser
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                });
            }
            ViewBag.userId = user.Id;
            return View(model);
        }
        [HttpPost]
        [Route("ManageUserRoles")]
        public async Task<IActionResult> ManageUserRoles(List<EditRolesInUser> editRolesInUsers, string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"user with Id = {Id} not fount";
                return View("Error/NotFound");
            }
            var role = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, role);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove roles");
                return View(editRolesInUsers);
            }
            result = await _userManager.AddToRolesAsync(user, editRolesInUsers.Where(x => x.IsSelected).Select(y => y.RoleName));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add roles");
                return View(editRolesInUsers);
            }
            return RedirectToAction("EditUser", new { Id = Id });

        }


        #endregion

        #region ROLES
        [HttpGet]
        [Route("ListRoles")]
        public IActionResult ListRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }
        
        [HttpGet]
        [Route("CreateRoles")]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateRoles")]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = createRoleViewModel.RoleManager
                };
                var result = await _roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Admin", "Admin");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(createRoleViewModel);
        }
               
        [HttpGet]
        [Route("EditRoles")]
        public async Task<IActionResult> EditRoles(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $" Role with Id = {Id} don't exist";
                return View("NotFound");
            }
            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };
            foreach (var user in _userManager.Users.ToList())
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }
        [HttpPost]
        [Route("EditRoles")]
        public async Task<IActionResult> EditRoles(EditRoleViewModel viewModel)
        {
            var role = await _roleManager.FindByIdAsync(viewModel.Id.ToString());
            if (role == null)
            {
                ViewBag.ErrorMessage = $" Role with Id = {viewModel.Id.ToString()} don't exist";
                return View("NotFound");
            }
            else
            {
                role.Name = viewModel.RoleName;
                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

                return View(viewModel);

            }
        }
        
        [HttpGet]
        [Route("EditUserInRole")]
        public async Task<IActionResult> EditUserInRole(string roleId)
        {
            ViewBag.Title = roleId;
            var role = await _roleManager.FindByIdAsync(roleId);
            var model = new List<UserRoleViewModel>();
            if (role == null)
            {
                ViewBag.ErrorMessage = $" Role with Id = {roleId} don't exist";
                return View("NotFound");
            }
            else
            {
                foreach (var user in _userManager.Users.ToList())
                {
                    var userRoleViewModel = new UserRoleViewModel
                    {
                        UserId = user.Id,
                        UserName = user.UserName
                    };
                    if (await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        userRoleViewModel.IsSelected = true;
                    }
                    else
                    {
                        userRoleViewModel.IsSelected = false;
                    }
                    model.Add(userRoleViewModel);
                }
            }
            return View(model);
        }
        
        [HttpPost]
        [Route("EditUserInRole")]
        public async Task<IActionResult> EditUserInRole(List<UserRoleViewModel> model, string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with id = {roleId} don't exist";
                return View("NotFound");
            }
            else
            {
                for (int i = 0; i < model.Count; i++)
                {
                    var user = await _userManager.FindByIdAsync(model[i].UserId);

                    IdentityResult result = null;
                    if (model[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                    {
                        result = await _userManager.AddToRoleAsync(user, role.Name);
                    }
                    else if (!model[i].IsSelected && (await _userManager.IsInRoleAsync(user, role.Name)))
                    {
                        result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                    }
                    else
                    {
                        continue;
                    }
                    if (result.Succeeded)
                    {
                        if (i < (model.Count - 1))
                            continue;
                        else
                            return RedirectToAction("EditRoles", new { Id = roleId });
                    }
                }
            }
            return RedirectToAction("EditRoles", new { Id = roleId }); ;
        }
        [Route("DeleteRole")]
        public async Task<IActionResult> DeleteRole(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {Id} not fount";
                return View("Error/NotFound");
            }
            else
            {
                try
                {
                    var result = await _roleManager.DeleteAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListRoles");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View("ListRoles");
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorTitle = $"{role.Name} role in use";
                    ViewBag.TitleMessage = ex.Message + "\r\n" +
                        $"{role.Name} role have some users. If you want to  delete this roe I should delete users";
                    return View("Error");
                }
            }

        }

        #endregion

        #region CLAIMS
        [Route("ManageUserClaims")]
        [HttpGet]
        public async Task<IActionResult> ManageUserClaims(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"user with Id = {Id} not fount";
                return View("Error/NotFound");
            }
            var existingUserClaims = await _userManager.GetClaimsAsync(user);
            var model = new EditUserClaimsViewModel
            {
                UserId = Id
            };
            foreach (Claim claim in ClaimStore.AllClaims)
            {
                UserClaims userClaims = new UserClaims
                {
                    ClaimType = claim.Type
                };
                if (existingUserClaims.Any(c => c.Type == claim.Type))
                {
                    userClaims.IsSelected = true;
                }
                model.Claims.Add(userClaims);
            }


            return View(model);
        }
        [Route("ManageUserClaims")]

        [HttpPost]
        public async Task<IActionResult> ManageUserClaims(EditUserClaimsViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"user with Id = {model.UserId} not fount";
                return View("Error/NotFound");
            }
            var claims = await _userManager.GetClaimsAsync(user);
            var result = await _userManager.RemoveClaimsAsync(user, claims);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove roles");
                return View(model);
            }
            result = await _userManager.AddClaimsAsync(user, model.Claims.Where(x => x.IsSelected).Select(c => new Claim(c.ClaimType, c.ClaimType)));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add roles");
                return View(model);
            }
            return RedirectToAction("EditUser", new { Id = model.UserId });
        }

        #endregion


    }
}
