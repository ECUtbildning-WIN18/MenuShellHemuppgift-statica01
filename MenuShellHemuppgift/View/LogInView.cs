using System;
using System.Threading;
using MenuShellHemuppgift.Domain;
using MenuShellHemuppgift.Services;

namespace MenuShellHemuppgift.View
{
    class LogInView : BaseView
    {
        private readonly IAuthenticationService _authenticationService;

        public LogInView(IAuthenticationService authenticationService) : base("Login")
        {

            _authenticationService = authenticationService;
        }

        public User Display()
        {
            User authenticateUser = null;

            do
            {
                Console.Clear();
                Console.WriteLine("Please log in\n");

                Console.Write("Username: ");
                string username = Console.ReadLine();

                Console.Write("Password: ");
                string password = Console.ReadLine();

                Console.WriteLine("\nIs this correct? (Y)es (N)o");

                var keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Y)
                {
                    authenticateUser = _authenticationService.Authenticate(username, password);

                    if (authenticateUser == null)
                    {
                        Console.Clear();
                        Console.WriteLine("\nLogin failed, check your details and try again");
                        Thread.Sleep(3000);
                    }
                }

            } while (authenticateUser == null);

            return authenticateUser;
        }
    }
}

