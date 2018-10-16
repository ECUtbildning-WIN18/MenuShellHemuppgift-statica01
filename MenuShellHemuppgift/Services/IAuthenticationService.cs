using MenuShellHemuppgift.Domain;

namespace MenuShellHemuppgift.Services
{
    interface IAuthenticationService
    {
        User Authenticate(string username, string password);
    }
}
