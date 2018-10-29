
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

        //public IEnumerable<string> Display() <----- Code connected to my other solution in ListUserView
        public IDictionary<string, User> Display()
        {
            // User userList = null; <----- Code connected to my other solution in ListUserView

            Console.Clear();
            Console.WriteLine("Search all users.\n");

            Console.Write("Search by username: ");
            //var dictionarySearch = Console.ReadLine().ToLower();  <----- Code connected to my other solution in ListUserView
            var searchWord = Console.ReadLine().ToLower();
            var filteredList = (IDictionary<string, User>)_users.Where(x => x.Value.Username.Contains(searchWord));
            // var filteredList = _users.Where(x => x.Value.Username.Contains(dictionarySearch)).Select(x => x.Key);
            // ^----- Code connected to my other solution in ListUserView

            return filteredList;
        }
    }
}
