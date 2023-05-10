using MilleniumRecruitmentTask.Models;

namespace MilleniumRecruitmentTask.Data
{
    public class UserInMemoryRepository : IUserRepository
    {
        private List<User> users;

        public UserInMemoryRepository()
        {
            users = new List<User>();
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
            catch(Exception ex)
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
