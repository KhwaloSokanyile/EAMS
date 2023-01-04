using EMS.Models;
using EMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    public class SignUpController : Controller
    {
        private readonly ISignUpRepo _signUpRepo;
        public SignUpController(ISignUpRepo signUpRepo)
        {
            _signUpRepo = signUpRepo;
        }


        [Route("signup")]
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUp signUp)
        {
            if(ModelState.IsValid)
            {
                var result = await _signUpRepo.CreateUser(signUp);
                if (!result.Succeeded)
                {
                    foreach(var e in result.Errors)
                    {
                        ModelState.AddModelError("",e.Description);
                    }
                    return View(signUp);
                }
                
            }
            return View(); 
        }

        [Route("signin")]
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [Route("signin")]
        [HttpPost]
        public async Task<IActionResult> SignIn(SignIn signIn)
        {
            if (ModelState.IsValid)
            {
                var result = await _signUpRepo.PasswordSignIn(signIn);
                
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid credentials");
                
            }
            return View(signIn);
               
        }
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signUpRepo.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
