using ConnectDellBack.Controllers;
using ConnectDellBack.Services;
using ConnectDellBack.Models;
using Microsoft.AspNetCore.Mvc;
using ConnectDellBack.DTOs;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Microsoft.Extensions.Logging.Abstractions;

namespace ConnectDellBack.Tests
{
    [TestFixture]
    public class UserControllerTest
    {
        private static DbContextOptions<ApplicationContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationContext>()
                                                                                .UseInMemoryDatabase(databaseName: "DbControllerTest")
                                                                                .Options;
        ApplicationContext context;
        UserService userService;
        UserController userController;

        [OneTimeSetUp]
        public void SetUp()
        {
            context = new ApplicationContext(dbContextOptions);
            context.Database.EnsureCreated();

            userService = new UserService(context);
            userController = new UserController(new NullLogger<UserController>(), userService);
        }

        [Test, Order(1)]
        public void Get_OwnersFromDB_ReturnOwnerCountOnController()
        {
            var result = userController.GetOwners();
            Assert.That(result.Count, Is.EqualTo(4));
        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.OkObjectResult")]
        public async Task<String> Get_ListUsers_ReturnOkObject()
        {
            ActionResult<IEnumerable<UserDTO>> actionResult = await userController.ListUsers();

            return actionResult.Result.ToString();
        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.OkResult")]
        public async Task<String> Get_ChangeRole_ReturnOkResult()
        {
            ActionResult actionResult = await userController.ChangeRole(1,1);

            return actionResult.ToString();
        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.OkResult")]
        public async Task<String> Get_RemoveResult_ReturnOkResult()
        {
            ActionResult actionResult = await userController.RemoveUser(1);

            return actionResult.ToString();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }


    }
}
