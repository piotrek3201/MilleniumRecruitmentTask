using MilleniumRecruitmentTask.Data;
using MilleniumRecruitmentTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilleniumRecruitmentTaskTests
{
    public class UserRepositoryFake : IUserRepository
    {
        public List<User> users;

        public UserRepositoryFake()
        {
            users = new List<User>() 
            {
                new User()
                {
                    UserId = 1,
                    UserName = "piotr",
                    UserAge = 23
                },
                new User()
                {
                    UserId = 2,
                    UserName = "jan",
                    UserAge = 30
                },
                new User()
                {
                    UserId = 3,
                    UserName = "andrzej",
                    UserAge = 40
                }
            };

        }

        public bool AddUser(User user)
        {
            try
            {
                if (users.Count > 0)
                {
                    var maxId = users.Max(x => x.UserId) + 1;
                    user.UserId = maxId;
                }
                else
                {
                    user.UserId = 0;
                }

                users.Add(user);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                var userToDelete = GetUserById(userId);
                if (userToDelete != null)
                {
                    users.Remove(userToDelete);
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                var userToUpdate = GetUserById(user.UserId);
                if (userToUpdate != null)
                {
                    userToUpdate.UserName = user.UserName;
                    userToUpdate.UserAge = user.UserAge;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public User? GetUserById(int userId)
        {
            return users.FirstOrDefault(x => x.UserId == userId);
        }
    }
}
