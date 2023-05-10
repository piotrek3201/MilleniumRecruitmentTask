using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilleniumRecruitmentTask.Data;
using MilleniumRecruitmentTask.Models;

namespace MilleniumRecruitmentTask.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger<UserController> logger;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }

        [HttpGet("all")]
        public ActionResult<List<User>> GetAllUsers()
        {
            logger.LogInformation("GET all users called.");
            return userRepository.GetAllUsers();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            logger.LogInformation("GET user by id {id} called.", id);
            var user = userRepository.GetUserById(id);
            if (user == null)
            {
                logger.LogWarning("User {id} does not exist", id);
                return NotFound();
            }
            else
            {
                return user;
            }
        }

        [HttpPost("add")]
        public ActionResult AddUser(User user)
        {
            logger.LogInformation("ADD user called.");
            bool createSuccesful = userRepository.AddUser(user);
            if (createSuccesful)
            {
                return Ok();
            }
            else
            {
                logger.LogWarning("Did not add user");
                return BadRequest();
            }
        }

        [HttpPut("update")]
        public ActionResult UpdateUser(User user)
        {
            logger.LogInformation("UPDATE user called.");
            bool updateSuccesful = userRepository.UpdateUser(user);
            if (updateSuccesful)
            {
                return Ok();
            }
            else
            {
                logger.LogWarning("Did not update user");
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        public ActionResult DeleteUser(int userId)
        {
            logger.LogInformation("DELETE user {id} called.", userId);
            bool deleteSuccesful = userRepository.DeleteUser(userId);
            if (deleteSuccesful)
            {
                return Ok();
            }
            else
            {
                logger.LogWarning("Did not delete user {id}", userId);
                return BadRequest();
            }
        }
    }
}
