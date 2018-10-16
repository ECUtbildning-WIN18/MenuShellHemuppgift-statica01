using MenuShellHemuppgift.Domain;
using MenuShellHemuppgift.Services;
using MenuShellHemuppgift.View;

namespace MenuShellHemuppgift
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new UserTestService();
            var authenticationService = new AuthenticationService(user);

            var logInView= new LogInView(authenticationService);

            var authenticateUser = logInView.Display();

            if (authenticateUser.Role == Role.Administrator)
            {
                var adminMainView = new AdminMainView(user.LoadUsers());
                adminMainView.Display();
            } 
        }
    }
}
