using MenuShellHemuppgift.Domain;
using MenuShellHemuppgift.Services;
using MenuShellHemuppgift.View;

namespace MenuShellHemuppgift
{
    class Program
    {
        static void Main(string[] args)
        {
           // var user = new UserTestService();
            var userService = new SqlUserService();
            var authenticationService = new AuthenticationService(userService);

            var logInView= new LogInView(authenticationService);

            var authenticateUser = logInView.Display();

            if (authenticateUser.Role == Role.administrator)
            {
                var adminMainView = new AdminMainView(userService.LoadUsers());
                adminMainView.Display();
            } 
           /*else if (authenticateUser.Role == Role.receptionist)
            {
                var receptionistMainView = new ReceptionistMainView();
                receptionistMainView.Display();
            }*/
        }
    }
}
