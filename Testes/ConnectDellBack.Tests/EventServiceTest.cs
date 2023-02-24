using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConnectDellBack.Models;
using NUnit.Framework;
using ConnectDellBack.Services;
using ConnectDellBack.DTOs;
using System.Linq;
using Microsoft.OpenApi.Any;

namespace ConnectDellBack.Tests
{
    [TestFixture]
    internal class EventServiceTest
    {
        private static DbContextOptions<ApplicationContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationContext>()
                                                                                .UseInMemoryDatabase(databaseName: "DbTest")
                                                                                .Options;
        ApplicationContext context;
        EventService eventService;

        [OneTimeSetUp]
        public void SetUp()
        {
            context = new ApplicationContext(dbContextOptions);
            context.Database.EnsureCreated();

            eventService = new EventService(context);
        }

        [Test]
        [TestCase(ExpectedResult = 12)]
        public async Task<int> getAllEvents_Return12()
        {
            // Right now there are 12 events being seeded in the ApplicationContext on the first edition
            var list = await  eventService.getAllEvents(1);
            var result = list.Count();

            return result;
        }

        [Test]
        [TestCase(ExpectedResult = 0)]
        public async Task<int> getAllEvents_EmptyEdition_Returns0()
        {
            // Right now there are no events being seeded in the ApplicationContext on the second edition
            var list = await eventService.getAllEvents(2);
            var result = list.Count();
            return result;
            
        }
        [Test]
        [TestCase(ExpectedResult = 0)]
        public async Task<int> getAllEvents_InvalidId_Returns0()
        {
            // This id doesnt exist in the ApplicationContext
            var list = await eventService.getAllEvents(9921659);
            var result = list.Count();
            return result;
        }


        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

    }
}