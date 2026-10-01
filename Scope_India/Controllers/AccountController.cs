using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Scope_India.DAL;
using Scope_India.DATA;
using Scope_India.ViewModels;
using System.Security.Claims;

namespace Scope_India.Controllers
{
    public class AccountController : Controller
    {
        private readonly IStudent _studentRepo;
        private readonly IEmailSender _emailSender;

        public AccountController(IStudent studentRepo, IEmailSender emailSender)
        {
            _studentRepo = studentRepo;
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult Login() => View(new LoginViewModel());

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var student = await _studentRepo.GetByEmailAsync(model.Email);

            if (student == null || !VerifyPassword(model.Password, student.PasswordHash))
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, student.FullName),
                new Claim(ClaimTypes.Email, student.Email),
                new Claim(ClaimTypes.NameIdentifier, student.Id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties { IsPersistent = model.RememberMe }
            );

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentRepo.GetByIdAsync(id);
            if (student == null) return NotFound();

            var hobbyList = string.IsNullOrWhiteSpace(student.Hobbies)
                ? new List<string>()
                : student.Hobbies.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();

            var model = new StudentViewModel
            {
                Id = student.Id,
                FullName = student.FullName,
                Email = student.Email,
                Gender = student.Gender,
                PhoneNumber = student.PhoneNumber,
                CourseId = student.CourseId,
                AvatarPath = student.AvatarPath,
                SelectedHobbies = hobbyList
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        // --- your existing Register actions stay below ---

        [HttpGet]
        public IActionResult Register() => View(new RegisterViewModel());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var existing = await _studentRepo.GetByEmailAsync(model.Email);
            if (existing != null)
            {
                ModelState.AddModelError("Email", "An account with this email already exists.");
                return View(model);
            }

            var hobbies = model.SelectedHobbies.ToList();
            if (model.AddCustomHobby && !string.IsNullOrWhiteSpace(model.CustomHobby))
                hobbies.Add(model.CustomHobby.Trim());

            var student = new Student
            {
                FullName = model.FullName,
                Email = model.Email,
                PasswordHash = HashPassword(model.Password),
                Hobbies = string.Join(",", hobbies)
            };

            await _studentRepo.InsertAsync(student);

            return RedirectToAction("Login");
        }

        private string HashPassword(string password)=>PasswordHasher.HashPassword(password);
        
        private bool VerifyPassword(string inputPassword, string storedHash)=>PasswordHasher.VerifyPassword(inputPassword, storedHash);
        
    }
}