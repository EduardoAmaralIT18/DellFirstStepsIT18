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

        [Test]
        public void Get_OwnersFromDB_ReturnOwnerCountOnController()
        {
            var result = userController.GetOwners();
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }


    }
}
