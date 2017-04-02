using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Options;
using BeerBuddy.Models;
using Dapper;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BeerBuddy.Factory
{
    public class UserFactory : IFactory<User> 
    {
        private readonly IOptions<MySqlOptions> mysqlConfig;
        
        public UserFactory(IOptions<MySqlOptions> conf) {
                mysqlConfig = conf;
        }
    
        internal IDbConnection Connection {
            get 
            {
                return new MySqlConnection(mysqlConfig.Value.ConnectionString);
            }
        }

    public void AddUser(User user)
    {
        using(IDbConnection dbConnection = Connection)
        {
            string query = "INSERT into Users (username, fname, lname, email, password, createdAt, updatedAt) VALUES (@username, @fname, @lname, @email, @password, NOW(), NOW())";
            dbConnection.Open();
            dbConnection.Execute(query, user);
        }
      
    }
    public User GetCurrentUser(string email)
    {
        using(IDbConnection dbConnection = Connection)
        {
            string query = $"SELECT * FROM Users WHERE email = '{email}' LIMIT 1";
            dbConnection.Open();
            User current = dbConnection.QuerySingleOrDefault<User>(query);
            System.Console.WriteLine(current);
            return current;
        }
    }

    public User GetUserByID(int id)
    {
        using(IDbConnection dbConnection = Connection)
        {
            string query = $"SELECT * FROM Users WHERE id = {id} LIMIT 1";
            dbConnection.Open();
            User current = dbConnection.QuerySingleOrDefault<User>(query);
            System.Console.WriteLine(current);
            return current;
        }
    }

    public bool CheckUserInDB(string email){
        User newUser = GetCurrentUser(email);
        return newUser != null;
    }

    public bool CheckLogin(User user)
    {
        User newUser = GetCurrentUser(user.email);
        var hasher = new PasswordHasher<User>();
        if(0 != hasher.VerifyHashedPassword(user, user.password, newUser.password))
        {
            return true;
        }
        return false;
    }

    // public List<User> GetConnectedUsers(int uid)
    // {
    //     List<User> connectedUsers = new List<User>();
    //     using(IDbConnection dbConnection = Connection)
    //     {
    //         string query = $"select distinct Users.id, Users.name, Usersc.id, Usersc.name from Users join connections on {uid} = connections.userId1 or {uid} = connections.userId2 join Users Usersc on (Users.id = connections.userId1 and Usersc.id <> Users.id and connections.accepted = 1) or (Usersc.id = connections.userId2 and Usersc.id <> Users.id and connections.accepted = 1)";
    //         dbConnection.Open();
    //         connectedUsers = dbConnection.Query<User>(query).ToList();
    //         return connectedUsers;
    //     }
    // }

    // public List<User> GetRequestedUsers(int uid)
    // {
    //     List<User> requestedUsers = new List<User>();
    //     using(IDbConnection dbConnection = Connection)
    //     {
    //         string query = $"select distinct Users.id, Users.name, Usersc.id, Usersc.name from Users join connections on {uid} = connections.userId1 or {uid} = connections.userId2 join Users Usersc on (Users.id = connections.userId1 and Usersc.id <> Users.id and connections.accepted = 0) or (Usersc.id = connections.userId2 and Usersc.id <> Users.id and connections.accepted = 0)";
    //         dbConnection.Open();
    //         requestedUsers = dbConnection.Query<User>(query).ToList();
    //         return requestedUsers;
    //     }
    // }

    // public List<User> GetOtherUsers(int uid)
    // {
    //     List<User> otherUsers = new List<User>();
    //     using(IDbConnection dbConnection = Connection)
    //     {
    //         string query = $"select Users.id, Users.name, Usersc.id, Usersc.name from Users join connections on {uid} = connections.userId1 or {uid} = connections.userId2 join Users Usersc on (Users.id = connections.userId1 and Usersc.id <> Users.id and connections.accepted = 0) or (Usersc.id = connections.userId2 and Usersc.id <> Users.id and connections.accepted = 0)";
    //         dbConnection.Open();
    //         otherUsers = dbConnection.Query<User>(query).ToList();
    //         return otherUsers;
    //     }
    // }

    // public List<User> GetAllUsers()
    // {
    //     using(IDbConnection dbConnection = Connection)
    //     {
    //         // List<User> allUsers = new List<User>();
    //         string query = $"select * from Users";
    //         dbConnection.Open();
    //         var allUsers = dbConnection.Query<User>(query).ToList();
    //         return allUsers;
    //     }
    // }

    // public void AddConnection(int cuid, int ouid)
    // {
    //     using(IDbConnection dbConnection = Connection)
    //     {
    //         string query = $"INSERT into connections (userId1, userId2, accepted) VALUES ({cuid}, {ouid}, false)";
    //         dbConnection.Open();
    //         dbConnection.Execute(query);
    //     }
    // }

    // public void AcceptConnection(int cuid, int ouid)
    // {
    //     using(IDbConnection dbConnection = Connection)
    //     {
    //         string query = $"UPDATE connections SET accepted = 1 WHERE userId1 = {ouid} AND userId2 = {cuid}";
    //         dbConnection.Open();
    //         dbConnection.Execute(query);
    //     }
    // }

    // public void DeleteConnection(int cuid, int ouid)
    // {
    //     using(IDbConnection dbConnection = Connection)
    //     {
    //         string query = $"DELETE FROM connections WHERE userId1 = {ouid} AND userId2 = {cuid}";
    //         dbConnection.Open();
    //         dbConnection.Execute(query);
    //     }
    // }


    }
}