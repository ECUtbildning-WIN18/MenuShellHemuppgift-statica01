using System.Collections.Generic;
using MenuShellHemuppgift.Domain;

namespace MenuShellHemuppgift.Services
{
    interface IUserService
    {
        IDictionary<string, User> LoadUsers();
    }
}
