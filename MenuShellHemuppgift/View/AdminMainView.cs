using System;
using System.Collections.Generic;
using MenuShellHemuppgift.Domain;

namespace MenuShellHemuppgift.View
{
    class AdminMainView : BaseView
    {
        private static int _index = 0;
        private readonly IDictionary<string, User> _users;

        public AdminMainView(IDictionary<string, User> users) : base("Admin main view") => _users = users;

        public void Display()
        {
            Console.Clear();  
            List<string> menuItems = new List<string>()
            {
                "Manage users",
                "Exit"
            };

            Console.CursorVisible = false;
            while (true)
            {
                string selectedMenuItem = DrawMenu(menuItems);
                if (selectedMenuItem == "Manage users")
                {
                    Console.Clear();
                    var adminManageUserView = new AdminManageUserView(_users); 
                    adminManageUserView.Display();
                    Console.Read();
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

            ConsoleKeyInfo ckey = Console.ReadKey();

            if (ckey.Key == ConsoleKey.DownArrow)
            {
                if (_index == items.Count - 1)
                {
                }
                else
                {
                    _index++;
                }
            }
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (_index <= 0)
                {
                }
                else
                {
                    _index--;
                }
            }
            else if (ckey.Key == ConsoleKey.Enter)
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

