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
        [TestCase(ExpectedResult = 32)]
        public async Task<int> get_AllUsersFromDB_ReturnUserCount()
        {
            var result = await userService.ListUsers();

            return result.Count();
        }

        [Test, Order(1)]
        public void get_OwnersFromDB_ReturnOwnerCount()
        {
            var result = userService.GetOwners();
            Assert.That(result.Count, Is.EqualTo(4));
        }

        [Test]
        [TestCase(ExpectedResult = 1)]
        public async Task<int> ChangeRole_ReturnOneEntryAltered(){
            var result = await userService.ChangeRole(1, 1);

            return result;
        }

        [Test]
        [TestCase(ExpectedResult = 1)]
        public async Task<int> RemoveUser_ReturnOneEntryAltered()
        {
            var result = await userService.RemoveUser(1);

            return result;
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }


    }
}
