﻿using System;
using System.Collections.Generic;
using System.Threading;
using MenuShellHemuppgift.Domain;

namespace MenuShellHemuppgift.View
{
    class RegisterNewUserView : BaseView
    {
        private readonly IDictionary<string, User> _users;

        public RegisterNewUserView(IDictionary<string, User> users) : base("Admin, add user view") => _users = users;

        public void Display()
        {
            bool correctInformation = true;
            do
            {
                Console.Clear();

                Console.Write("Username: ");
                var username = Console.ReadLine();

                Console.Write("Password: ");
                var password = Console.ReadLine();

                Console.Write("Add user role: ");
                var role = Console.ReadLine();
                
                Console.Write("Is this correct? (Y)es (N)o");

                var correctChoice = Console.ReadKey(true);

                var user = new User(username, password, (Role)Enum.Parse(typeof(Role), role));

                if (!_users.ContainsKey(user.Username))
                {
                    _users.Add(user.Username, user);
                    correctInformation = false;
                }
                else
                {
                    Console.Write("User already exists.");
                    Thread.Sleep(3000);
                }
            } while (correctInformation);
        }
    }
}
