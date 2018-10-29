using System;
using System.Collections.Generic;
using MenuShellHemuppgift.Domain;

namespace MenuShellHemuppgift.View
{
    class ListUsersView : BaseView
    {

        private readonly IDictionary<string, User> _users;
        private readonly IDictionary<string, User> _foundUsers;

        public ListUsersView(IDictionary<string, User> users) : base("Remove user") => _users = users;
        public ListUsersView(IDictionary<string, User> foundUsers, IDictionary<string, User> users) : base("Remove user")
        {
            _users = users;
            _foundUsers = foundUsers;
        }

        public void Display()
        {
            bool correctInformation = true;

            if (_foundUsers.Count == 0)
            {
                Console.WriteLine("No users includes your search term. Please try again.");
                return;
            }

            do
            {
                Console.Clear();
                foreach (var foundUser in _foundUsers)
                {
                    Console.WriteLine(foundUser.Value.Username);
                }

                Console.WriteLine("Which user do you wanna delete?");

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
        //My first solution for the code, not working but saving it here since I´m unsure which one to use

        /* private readonly IDictionary<string, User> _users;

         public ListUsersView(IDictionary<string, User> users) : base("Remove user") => _users = users;

         public void Display()
         {
             bool correctInformation = true;


             if (dictionarySearch.Contains(filteredList))
             {
                 foreach (var user in filteredList)
                 {
                     var listUsersView = new ListUsersView(_users);
                     listUsersView.Display();
                 }
             }
             else
             {
                 Console.WriteLine("No users includes your search term. Please try again.");
             }


             while (userList == null) ;
             do
             {
                 Console.Clear();
                 foreach (var user in _users)
                 {
                     Console.WriteLine(user.Value.Username);
                 }

                 Console.WriteLine("Which user do you wanna delete?");

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
         }*/
    }
}
