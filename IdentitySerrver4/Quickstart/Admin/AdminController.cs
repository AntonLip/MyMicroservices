using IdentitySerrver4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityServerHost.Quickstart.UI
{
   // [Authorize(Roles = "Admin")]
   
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManagerQ;
        private readonly UserManager<AppUser> userManagerQ;
        public AdminController(RoleManager<IdentityRole> roleManager,
                               UserManager<AppUser> userManager)
        {
            _roleManagerQ = roleManager;
            userManagerQ = userManager;
        }

        [HttpGet]
        public IActionResult ListUsers()
        {            
            var users = userManagerQ.Users;
            return View(users);
        }

        //[HttpGet]
        //public IActionResult CreateRole()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        IdentityRole identityRole = new IdentityRole
        //        {
        //            Name = createRoleViewModel.RoleManager
        //        };
        //        var result = await _roleManagerQ.CreateAsync(identityRole);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError(string.Empty, error.Description);
        //            }
        //        }
        //    }
        //    return View(createRoleViewModel);
        //}
        //[HttpGet]
        //public IActionResult ListRoles()
        //{
        //    var roles = _roleManagerQ.Roles;
        //    return View(roles);
        //}
        //[HttpGet]
        //public async Task<IActionResult> EditRoles(string Id)
        //{
        //    var role = await _roleManagerQ.FindByIdAsync(Id);
        //    if (role == null)
        //    {
        //        ViewBag.ErrorMessage = $" Role with Id = {Id} don't exist";
        //        return View("NotFound");
        //    }
        //    var model = new EditRoleViewModel
        //    {
        //        Id = role.Id,
        //        RoleName = role.Name
        //    };
        //    foreach (var user in userManagerQ.Users.ToList())
        //    {
        //        if (await userManagerQ.IsInRoleAsync(user, role.Name))
        //        {
        //            model.Users.Add(user.UserName);
        //        }
        //    }

        //    return View(model);
        //}
        //[HttpPost]
        //public async Task<IActionResult> EditRoles(EditRoleViewModel viewModel)
        //{
        //    var role = await _roleManagerQ.FindByIdAsync(viewModel.Id.ToString());
        //    if (role == null)
        //    {
        //        ViewBag.ErrorMessage = $" Role with Id = {viewModel.Id.ToString()} don't exist";
        //        return View("NotFound");
        //    }
        //    else
        //    {
        //        role.Name = viewModel.RoleName;
        //        var result = await _roleManagerQ.UpdateAsync(role);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("ListRoles");
        //        }
        //        else
        //        {
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError(string.Empty, error.Description);
        //            }
        //        }

        //        return View(viewModel);

        //    }
        //}
        //[HttpGet]
        //public async Task<IActionResult> EditUserInRole(string roleId)
        //{
        //    ViewBag.Title = roleId;
        //    var role = await _roleManagerQ.FindByIdAsync(roleId);
        //    var model = new List<UserRoleViewModel>();
        //    if (role == null)
        //    {
        //        ViewBag.ErrorMessage = $" Role with Id = {roleId} don't exist";
        //        return View("NotFound");
        //    }
        //    else
        //    {
        //        foreach (var user in userManagerQ.Users.ToList())
        //        {
        //            var userRoleViewModel = new UserRoleViewModel
        //            {
        //                UserId = user.Id,
        //                UserName = user.UserName
        //            };
        //            if (await userManagerQ.IsInRoleAsync(user, role.Name))
        //            {
        //                userRoleViewModel.IsSelected = true;
        //            }
        //            else
        //            {
        //                userRoleViewModel.IsSelected = false;
        //            }
        //            model.Add(userRoleViewModel);
        //        }
        //    }
        //    return View(model);
        //}
        //[HttpPost]
        //public async Task<IActionResult> EditUserInRole(List<UserRoleViewModel> model, string roleId)
        //{
        //    var role = await _roleManagerQ.FindByIdAsync(roleId);
        //    if (role == null)
        //    {
        //        ViewBag.ErrorMessage = $"Role with id = {roleId} don't exist";
        //        return View("NotFound");
        //    }
        //    else
        //    {
        //        for (int i = 0; i < model.Count; i++)
        //        {
        //            var user = await userManagerQ.FindByIdAsync(model[i].UserId);

        //            IdentityResult result = null;
        //            if (model[i].IsSelected && !(await userManagerQ.IsInRoleAsync(user, role.Name)))
        //            {
        //                result = await userManagerQ.AddToRoleAsync(user, role.Name);
        //            }
        //            else if (!model[i].IsSelected && (await userManagerQ.IsInRoleAsync(user, role.Name)))
        //            {
        //                result = await userManagerQ.RemoveFromRoleAsync(user, role.Name);
        //            }
        //            else
        //            {
        //                continue;
        //            }
        //            if (result.Succeeded)
        //            {
        //                if (i < (model.Count - 1))
        //                    continue;
        //                else
        //                    return RedirectToAction("EditRoles", new { Id = roleId });
        //            }
        //        }
        //    }
        //    return RedirectToAction("EditRoles", new { Id = roleId }); ;
        //}
        //[HttpGet]

        //public async Task<IActionResult> EditUser(string Id)
        //{
        //    var user = await userManagerQ.FindByIdAsync(Id);
        //    if (user == null)
        //    {
        //        ViewBag.ErrorMessage = $"User with Id = {Id} not fount";
        //        return View("NotFound");
        //    }
        //    var userRoles = await userManagerQ.GetRolesAsync(user);
        //    var userClaims = await userManagerQ.GetClaimsAsync(user);
        //    var model = new EditUserViewModel
        //    {
        //        Id = user.Id,
        //        UserName = user.UserName,
        //        Email = user.Email,
        //        Claims = userClaims.Select(c => c.Value).ToList(),
        //        Roles = userRoles
        //    };
        //    return View(model);
        //}
        //[HttpPost]
        //public async Task<IActionResult> EditUser(EditUserViewModel model)
        //{
        //    var user = await userManagerQ.FindByIdAsync(model.Id);
        //    if (user == null)
        //    {
        //        ViewBag.ErrorMessage = $"User with Id = {model.Id} not fount";
        //        return View("NotFound");
        //    }
        //    else
        //    {
        //        user.UserName = model.UserName;
        //        user.Email = model.Email;
        //        user.City = model.City;

        //        var result = await userManagerQ.UpdateAsync(user);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("ListUsers");
        //        }

        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError("", error.Description);
        //        }
        //    }

        //    return View(model);
        //}

        //public async Task<IActionResult> DeleteUser(string Id)
        //{
        //    var user = await userManagerQ.FindByIdAsync(Id);
        //    if (user == null)
        //    {
        //        ViewBag.ErrorMessage = $"User with Id = {Id} not fount";
        //        return View("Error/NotFound");
        //    }
        //    else
        //    {
        //        var result = await userManagerQ.DeleteAsync(user);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("ListUsers");
        //        }
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError("", error.Description);
        //        }
        //        return View("ListUsers");
        //    }

        //}
        //[HttpGet]
        //public async Task<IActionResult> ManageUserRoles(string Id)
        //{
        //    var user = await userManagerQ.FindByIdAsync(Id);
        //    if (user == null)
        //    {
        //        ViewBag.ErrorMessage = $"user with Id = {Id} not fount";
        //        return View("Error/NotFound");
        //    }
        //    var model = new List<EditRolesInUser>();
        //    foreach (var role in _roleManagerQ.Roles)
        //    {
        //        model.Add(new EditRolesInUser
        //        {
        //            RoleId = role.Id,
        //            RoleName = role.Name
        //        });
        //    }
        //    ViewBag.userId = user.Id;
        //    return View(model);
        //}
        //[HttpPost]
        //public async Task<IActionResult> ManageUserRoles(List<EditRolesInUser> editRolesInUsers, string Id)
        //{
        //    var user = await userManagerQ.FindByIdAsync(Id);
        //    if (user == null)
        //    {
        //        ViewBag.ErrorMessage = $"user with Id = {Id} not fount";
        //        return View("Error/NotFound");
        //    }
        //    var role = await userManagerQ.GetRolesAsync(user);
        //    var result = await userManagerQ.RemoveFromRolesAsync(user, role);
        //    if(!result.Succeeded)
        //    {
        //        ModelState.AddModelError("", "Cannot remove roles");
        //        return View(editRolesInUsers);
        //    }
        //    result = await userManagerQ.AddToRolesAsync(user, editRolesInUsers.Where(x => x.IsSelected).Select(y => y.RoleName));
        //    if (!result.Succeeded)
        //    {
        //        ModelState.AddModelError("", "Cannot add roles");
        //        return View(editRolesInUsers);
        //    }
        //    return RedirectToAction("EditUser", new { Id = Id});

        //}

        //public async Task<IActionResult> DeleteRole(string Id)
        //{
        //    var role = await _roleManagerQ.FindByIdAsync(Id);
        //    if (role == null)
        //    {
        //        ViewBag.ErrorMessage = $"Role with Id = {Id} not fount";
        //        return View("Error/NotFound");
        //    }
        //    else
        //    {
        //        try
        //        {
        //            var result = await _roleManagerQ.DeleteAsync(role);
        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("ListRoles");
        //            }
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError("", error.Description);
        //            }
        //            return View("ListRoles");
        //        }
        //        catch (Exception ex)
        //        {
        //            ViewBag.ErrorTitle = $"{role.Name} role in use";
        //            ViewBag.TitleMessage = ex.Message +"\r\n" +
        //                $"{role.Name} role have some users. If you want to  delete this roe I should delete users";
        //            return View("Error");
        //        }
        //    }

        //}
        //[HttpGet]
        //public async Task<IActionResult> ManageUserClaims(string Id)
        //{
        //    var user = await userManagerQ.FindByIdAsync(Id);
        //    if (user == null)
        //    {
        //        ViewBag.ErrorMessage = $"user with Id = {Id} not fount";
        //        return View("Error/NotFound");
        //    }
        //    var existingUserClaims = await userManagerQ.GetClaimsAsync(user);
        //    var model = new EditUserClaimsViewModel
        //    { 
        //        UserId = Id
        //    };
        //    foreach (Claim claim in ClaimStore.AllClaims)
        //    {
        //        UserClaims userClaims = new UserClaims
        //        {
        //            ClaimType = claim.Type
        //        };
        //        if (existingUserClaims.Any(c => c.Type == claim.Type))
        //        {
        //            userClaims.IsSelected = true;
        //        }
        //        model.Claims.Add(userClaims);
        //    }


        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> ManageUserClaims(EditUserClaimsViewModel model)
        //{
        //    var user = await userManagerQ.FindByIdAsync(model.UserId);
        //    if (user == null)
        //    {
        //        ViewBag.ErrorMessage = $"user with Id = {model.UserId} not fount";
        //        return View("Error/NotFound");
        //    }
        //    var claims = await userManagerQ.GetClaimsAsync(user);
        //    var result = await userManagerQ.RemoveClaimsAsync(user, claims);
        //    if(!result.Succeeded)
        //    {
        //        ModelState.AddModelError("", "Cannot remove roles");
        //        return View(model);
        //    }
        //    result = await userManagerQ.AddClaimsAsync(user, model.Claims.Where(x => x.IsSelected).Select(c => new Claim(c.ClaimType, c.ClaimType)));
        //    if (!result.Succeeded)
        //    {
        //        ModelState.AddModelError("", "Cannot add roles");
        //        return View(model);
        //    }
        //    return RedirectToAction("EditUser", new { Id = model.UserId });
        //}



        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenid()
        {
            return View();
        }
    }
}
