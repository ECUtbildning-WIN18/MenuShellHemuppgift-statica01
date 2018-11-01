
using System;
using System.Collections.Generic;
using System.Linq;
using MenuShellHemuppgift.Domain;

namespace MenuShellHemuppgift.View
{
    class SearchUsersView : BaseView
    {
        private readonly IDictionary<string, User> _users;

        public SearchUsersView(IDictionary<string, User> users) : base("Search user") => _users = users;

        public IDictionary<string, User> Display()
        {
            Console.Clear();
            Console.WriteLine("If you wanna search all users, just press enter.\n");

            Console.Write("Search by username: ");
           
            var searchWord = Console.ReadLine().ToLower();
            var filteredList = (IDictionary<string, User>) _users.Where(x => x.Value.Username.Contains(searchWord)).ToDictionary(x => x.Key, x => x.Value);
   
            return filteredList;
        }
    }
}
