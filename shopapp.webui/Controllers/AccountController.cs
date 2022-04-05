using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using shopapp.webui.Identity;
using shopapp.webui.Model;

namespace shopapp.webui.Controllers
{
    public class AccountController:Controller
    {
        /// <summary>
        /// test erhan
        /// </summary>
        private UserManager<User> _userManager;
        private SignInManager<User> _signinManager;
        public AccountController( UserManager<User> userManager,SignInManager<User> signinManager)
        {
            _userManager=userManager;
            _signinManager=signinManager;
        }
        public IActionResult login()
        {
            return View();
        }
         [HttpPost]
         public async Task<IActionResult> login(LoginModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var user= await _userManager.FindByNameAsync(model.Username);
            if(user==null)
            {
                ModelState.AddModelError("","Bu username ile hesap bulunamadı");
                return View(model);
            }
            var result=await _signinManager.PasswordSignInAsync(user,model.Password,false,false);
            if(result.Succeeded)
            {
                return RedirectToAction("CreateProduct","Admin");
            }
            return View();
        }
         public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                FirstName  = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email    
            };           

            var result = await _userManager.CreateAsync(user,model.Password);
            if(result.Succeeded)
            {
                // generate token
                // email
                return RedirectToAction("Login","Account");
            }

            ModelState.AddModelError("","Bilinmeyen hata oldu lütfen tekrar deneyiniz.");
            return View(model);
        }
         public async Task<IActionResult> logout()
         {
             await _signinManager.SignOutAsync();
             return RedirectToAction("Login","Account");
         }
    }
}