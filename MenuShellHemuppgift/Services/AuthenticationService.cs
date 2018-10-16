using MenuShellHemuppgift.Domain;

namespace MenuShellHemuppgift.Services
{
    class AuthenticationService :IAuthenticationService
    {
        private readonly IUserService _userService;

        public AuthenticationService(IUserService userService)
        {
            _userService = userService;
        }

        public User Authenticate(string username, string password)
        {
            User user= null;

            var users = _userService.LoadUsers();

            if (users.ContainsKey(username) && users[username].Password == password)
            {
                user = users[username];
            }
            return user;
        }
    }
}
