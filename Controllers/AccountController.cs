
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TalabatSmartVillage.Auth;
using TalabatSmartVillage.Dtos;

namespace Day8_Assigment.Controllers
{
    [AllowAnonymous]
    public partial class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppRole> roleManager;


        public AccountController(
            UserManager<AppUser> _userManager, 
            SignInManager<AppUser> _signInManager,
            RoleManager<AppRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;

        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerDto)
        {
            //check for ModelState
            if (ModelState.IsValid == true)
            {   //create AppUser 
                AppUser newUser = new AppUser
                {
                    FullName = registerDto.FullName,
                    Email = registerDto.Email,
                    UserName = registerDto.username,
                    PhoneNumber = registerDto.phone,
                    Address = registerDto.Address,
                    postalcode = registerDto.postalCode,
                    CreatedAt = DateTime.Now
                };
                //save it in Db Using UserManger
                IdentityResult result =
                        await userManager.CreateAsync(newUser, registerDto.password);

                //check for result if it success

                if (result.Succeeded)
                {
                    //create Roles Function 
                    //ByDefault Assign The Registed User to Role User

                    await createRoles();

                    await userManager.AddToRoleAsync(newUser,Roles.ADMIN.ToString());
                    //redirect to Login
                    // Send confirmation Email
                    return RedirectToAction("Login", "Account");

                }
                else
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }

            }
            else
            {
                return View(ModelState);
            }
            return View();
        }

        [HttpPost("adminReg")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAdmin(RegisterViewModel dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            // Check if email already exists
            var existing = await userManager.FindByEmailAsync(dto.Email);
            if (existing != null)
            {
                ModelState.AddModelError("", "An account with this email already exists.");
                return View(dto);
            }

            var newAdmin = new AppUser
            {
                FullName = dto.FullName,
                Email = dto.Email,
                UserName = dto.username,
                PhoneNumber = dto.phone,
                Address = dto.Address,
                CreatedAt = DateTime.Now
            };

            var result = await userManager.CreateAsync(newAdmin, dto.password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(newAdmin, Roles.ADMIN.ToString());

                return RedirectToAction("Dashboard");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(dto);
        }


        private async Task createRoles()
        {
          bool AdminExist = await roleManager.RoleExistsAsync(Roles.ADMIN.ToString());
          bool UserExist = await roleManager.RoleExistsAsync(Roles.USER.ToString());

            if (!AdminExist)
            {
                //create Admin Role
                await roleManager.CreateAsync(new AppRole { Name = Roles.ADMIN.ToString() });
            }
            if (!UserExist)
            {
                //create User Role
                await roleManager.CreateAsync(new AppRole { Name = Roles.USER.ToString() });
            }

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginDto)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByNameAsync(loginDto.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "The Email or Password is Incorrect");
                }
                else
                {
                    bool isVerified = await userManager.CheckPasswordAsync(user, loginDto.password);
                    if (isVerified)
                    {
                        await signInManager.SignInAsync(user, false);
                        //if his Role is admin redirect to admin dashboard Else User Dashboard
                        var roles = await userManager.GetRolesAsync(user);

                        if (roles.Contains(Roles.ADMIN.ToString()))
                        {
                            return RedirectToAction("Dashboard", "Admin");

                        }
                        else
                        {
                            return RedirectToAction("Index", "User");

                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "The Email or Password is Incorrect");
                    }
                }
            }

            return View(loginDto);

        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }



    }



}
