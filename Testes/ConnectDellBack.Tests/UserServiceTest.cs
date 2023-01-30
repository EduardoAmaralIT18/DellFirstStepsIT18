using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConnectDellBack.Models;
using NUnit.Framework;
using ConnectDellBack.Services;

namespace ConnectDellBack.Tests
{
    [TestFixture]
    internal class UserServiceTest
    {
        private static DbContextOptions<ApplicationContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationContext>()
                                                                                .UseInMemoryDatabase(databaseName: "DbTest")
                                                                                .Options;
        ApplicationContext context;
        UserService userService;

        [OneTimeSetUp]
        public void SetUp()
        {
            context = new ApplicationContext(dbContextOptions);
            context.Database.EnsureCreated();

            userService = new UserService(context);
        }

        [Test]
        public void get_AllUsersFromDB_ReturnUserCount()
        {
            var result = userService.listUsers();

            Assert.That(result.Count, Is.EqualTo(15));
        }

        [Test]
        public void get_OwnersFromDB_ReturnOwnerCount()
        {
            var result = userService.GetOwners();
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }


    }
}
