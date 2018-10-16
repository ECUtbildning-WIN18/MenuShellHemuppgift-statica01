using System;
using System.Collections.Generic;
using MenuShellHemuppgift.Domain;

namespace MenuShellHemuppgift.View
{
    class RemoveUserView : BaseView
    {
        private readonly IDictionary<string, User> _users;

        public RemoveUserView(IDictionary<string, User> users) : base("Remove user") => _users = users;

        public void Display()
        {
            bool correctInformation = true;

            do
            {
                Console.Clear();
                foreach (var user in _users)
                {
                    Console.WriteLine(user.Value.Username);
                }

                var choice = Console.ReadLine();
                if (_users.ContainsKey(choice))
                {
                    _users.Remove(choice);
                }
                else
                {
                    correctInformation = false;
                }     
            } while (correctInformation);
        }
    }
}
