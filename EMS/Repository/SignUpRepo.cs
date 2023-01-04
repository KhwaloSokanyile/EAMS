using EMS.Models;
using Microsoft.AspNetCore.Identity;

namespace EMS.Repository
{
    public class SignUpRepo : ISignUpRepo
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public SignUpRepo(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
      

        public async Task<IdentityResult> CreateUser(SignUp signUp)
        {
            var user = new ApplicationUser()
            {
                Name = signUp.Name,
                Surname = signUp.Surname,
                Email = signUp.Email,
                UserName = signUp.Email,
                
            };
            var result = await _userManager.CreateAsync(user, signUp.Password);
            return result;
        }

        public async Task<SignInResult> PasswordSignIn(SignIn signIn)
        {
            var result = await _signInManager.PasswordSignInAsync(signIn.Email, signIn.Password, signIn.RememberMe,false);
            return result;
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
