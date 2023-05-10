using MilleniumRecruitmentTask.Models;

namespace MilleniumRecruitmentTask.Data
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User? GetUserById(int userId);
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int userId);
    }
}
