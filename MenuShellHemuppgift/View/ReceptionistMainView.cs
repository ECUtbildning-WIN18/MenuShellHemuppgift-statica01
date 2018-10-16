using System;
using System.Collections.Generic;
using MenuShellHemuppgift.Domain;

namespace MenuShellHemuppgift.View
{
      class ReceptionistMainView : BaseView
        {
            private static int _index = 0;
            private readonly IDictionary<string, Customer> _customers;

            public ReceptionistMainView(IDictionary<string, Customer> customers) : base("Receptionist main view") =>
                _customers = customers;

            public void Display()
            {
                List<string> menuItems = new List<string> {
                "Register new customer",
                "Search for customer",
                "Exit"
            };

                Console.CursorVisible = false;
                while (true)
                {
                    string selectedMenuItem = DrawMenu(menuItems);

                    if (selectedMenuItem == "Register new customer")
                    {
                        Console.Clear();
                        //METHOD for Register new customer here (RegisterNewCustomer)
                        Console.WriteLine("TEST"); //Remove when method is inserted
                        Console.Read();
                    }
                    else if (selectedMenuItem == "Search for customer")
                    {
                        Console.Clear();
                        //METHOD for List all Customers here 
                        Console.WriteLine("TEST"); //Remove when method is inserted
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
                    else { _index++; }
                }
                else if (ckey.Key == ConsoleKey.UpArrow)
                {
                    if (_index <= 0)
                    {
                    }
                    else { _index--; }
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
