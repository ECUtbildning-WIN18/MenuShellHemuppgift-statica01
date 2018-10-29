using System.Collections.Generic;
using MenuShellHemuppgift.Domain;

namespace MenuShellHemuppgift.Services
{
    class UserTestService : IUserService
    {
        private readonly IDictionary<string, User> TestData = new Dictionary<string, User>
        {
            {"admin", new User("admin", "password", Role.administrator)},
            {"jane", new User("jane", "password", Role.receptionist)},
            {"john", new User("john", "password", Role.veterinarian)}
        };

        public IDictionary<string, User> LoadUsers()
        {
            return TestData;
        }
    }
}
