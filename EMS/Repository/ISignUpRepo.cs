using EMS.Models;
using Microsoft.AspNetCore.Identity;

namespace EMS.Repository
{
    public interface ISignUpRepo
    {
        Task<IdentityResult> CreateUser(SignUp signUp);
        Task<SignInResult> PasswordSignIn(SignIn signIn);

        Task SignOut();
    }
}