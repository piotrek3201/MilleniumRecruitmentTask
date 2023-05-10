using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MilleniumRecruitmentTask.Controllers;
using MilleniumRecruitmentTask.Data;
using MilleniumRecruitmentTask.Models;
using MilleniumRecruitmentTaskTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilleniumRecruitmentTask.Controllers.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        private readonly IUserRepository userRepository;
        private readonly UserController controller;

        public UserControllerTests()
        {
            userRepository = new UserRepositoryFake();
            controller = new UserController(userRepository, new NullLogger<UserController>());
        }

        [TestMethod()]
        public void GetAllUsers_ShouldReturnAllUsers()
        {
            var result = controller.GetAllUsers().Value;
            Assert.AreEqual(result.Count, 3);
        }

        [TestMethod()]
        public void GetUserByIdTest_ShouldReturnOneUser()
        {
            var result = controller.GetUserById(1).Value;
            Assert.IsInstanceOfType(result, typeof(User));
        }

        [TestMethod()]
        public void AddUserTest_ShouldAddUser()
        {
            var user = new User
            {
                UserName = "anna",
                UserAge = 18
            };
            controller.AddUser(user);
            var result = controller.GetAllUsers().Value;
            Assert.AreEqual(result.Count, 4);
        }

        [TestMethod()]
        public void UpdateUserTest_ShouldUpdateUser()
        {
            var user = new User
            {
                UserId = 1,
                UserName = "anna",
                UserAge = 18
            };
            controller.UpdateUser(user);
            var result = controller.GetUserById(1).Value;
            Assert.AreEqual(result.UserName, "anna");
        }

        [TestMethod()]
        public void DeleteUserTest_ShouldDeleteUser()
        {
            controller.DeleteUser(3);
            var result = controller.GetAllUsers().Value;
            Assert.AreEqual(result.Count, 2);
        }
    }
}