using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MenuShellHemuppgift.Domain;


namespace MenuShellHemuppgift.Services
{
    class SqlUserService : IUserService
    {
        public IDictionary<string, User> LoadUsers()
        {
            {
                var userList = new Dictionary<string, User>();

                var connectionString = "Data Source=(local);Initial Catalog=MenuShell1.1;Integrated Security=true";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var queryString = "SELECT Username, Password, [Role] FROM Users";
                    var sqlCommand = new SqlCommand(queryString, connection);

                    try
                    {
                        var reader = sqlCommand.ExecuteReader();

                        while (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var username = reader.GetString(0);
                                var password = reader.GetString(1);
                                var role = reader.GetString(2);

                                var user = new User(username, password, (Role)Enum.Parse(typeof(Role), role));
                                userList.Add(username, user);
                            }

                            reader.NextResult();
                        }

                        reader.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
                return userList;
            }
        }
    }
}
