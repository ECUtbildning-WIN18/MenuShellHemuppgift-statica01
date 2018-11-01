using System;
using System.Collections.Generic;
using MenuShellHemuppgift.Domain;

namespace MenuShellHemuppgift.View
{
    class AdminManageUserView : BaseView
    {
        private static int _index = 0;
        private readonly IDictionary<string, User> _users;

        public AdminManageUserView(IDictionary<string, User> users) : base("Admin view") => _users = users;

        public void Display()
        {
            List<string> menuItems = new List<string>()
            {
                "Register new user",
                "Search user",
                "Exit"
            };

            Console.CursorVisible = false;
            while (true)
            {
                Console.Clear();
                string selectedMenuItem = DrawMenu(menuItems);
                if (selectedMenuItem == "Register new user")
                {
                    Console.Clear();
                    var registerNewUserView = new RegisterNewUserView(_users);
                    registerNewUserView.Display();
                   
                }
                else if (selectedMenuItem == "Search user")

                {
                    Console.Clear();
                    var searchUserView = new SearchUsersView(_users);

                    var foundUsers = searchUserView.Display();

                    var listUsersView = new ListUsersView(foundUsers, _users);

                    listUsersView.Display();

                }
                else if (selectedMenuItem == "Exit")
                {
                    Environment.Exit(0);
                }
            }
        }

        private static string DrawMenu(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (i == _index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine(items[i]);
                }
                else
                {
                    Console.WriteLine(items[i]);
                }
                Console.ResetColor();
            }

            ConsoleKeyInfo consolekey = Console.ReadKey();

            if (consolekey.Key == ConsoleKey.DownArrow)
            {
                if (_index == items.Count - 1)
                {
                }
                else
                {
                    _index++;
                }
            }
            else if (consolekey.Key == ConsoleKey.UpArrow)
            {
                if (_index <= 0)
                {
                }
                else
                {
                    _index--;
                }
            }
            else if (consolekey.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                return items[_index];
            }
            else
            {
                return "";
            }

            Console.Clear();
            return "";
        }
    }
}
