using System.Collections.Generic;
using MenuShellHemuppgift.Domain;

namespace MenuShellHemuppgift.Services
{
    class UserTestService : IUserService
    {
        private readonly IDictionary<string, User> TestData = new Dictionary<string, User>
        {
            {"admin", new User("admin", "admin", Role.Administrator)}
        };

        public IDictionary<string, User> LoadUsers()
        {
            return TestData;
        }
    }
}
