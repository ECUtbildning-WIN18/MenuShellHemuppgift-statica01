using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            bool incorrectInformation = true;

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
                    _foundUsers.Remove(choice);

                    var deleteString = String.Format("delete from Users where Username = '{0}'", choice);

                    var connectionString = "Data Source=(local);Initial Catalog=MenuShell1.1;Integrated Security=true";

                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand(deleteString, connection);
                        try
                        {
                            var rowsDeletedCount = command.ExecuteNonQuery();
                            if (rowsDeletedCount != 0)

                            command.Dispose();
                            connection.Close();
                            connection.Dispose();
                            incorrectInformation = false;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    }
                }
            } while (incorrectInformation);
        }
    }
}
