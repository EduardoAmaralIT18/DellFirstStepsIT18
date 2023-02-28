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
using System.Runtime.CompilerServices;
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
        EventsModel eventModel;
        EventDTO eventDTO;
        EditionModel modelToEvent;
       
       [OneTimeSetUp]
        public void SetUp()
        {
            context = new ApplicationContext(dbContextOptions);
            context.Database.EnsureCreated();

            eventService = new EventService(context);

            modelToEvent = new EditionModel()
            {
                id = 8,
                name = "Edition 99",
                startDate = new DateTime(2021, 10, 10),
                endDate = new DateTime(2022, 09, 10),
                description = "Sixteenth edition of the IT Academy program aimed at undergraduate students in computer science courses.",
                numberOfInterns = 20,
                mode = Mode.Remote,
                curriculum = "CSS, HTML, C#, JavaScript, SQL Server, Entity Framework, Asp.NET, Vue.js",
                program = context.programs.Where(prog => prog.id == 1).FirstOrDefault()
            };

            eventModel = new EventsModel()
            {
                id = 13,
                name = "Event test",
                phaseType = PhaseType.HandsOn,
                eventType = EventType.Activity,
                startDate = DateTime.Now,
                endDate = DateTime.Now,
                where = "remote",
                peopleInvolved = null,
                edition = modelToEvent

            };

            eventDTO = EventDTO.ConvertModel2DTO(eventModel);
        }


        [Test]
        [TestCase(ExpectedResult = true)]
        public async Task<bool> GetEventUpdated_ReturnTrue()
        {
            var eventExpected = context.events.Where(ev => ev.id == 1).FirstOrDefault();

            var eventServices = await eventService.GetEventToUpdate(1);
            return eventServices.Equals(eventExpected);


        }

        [Test]
        [TestCase(ExpectedResult = true)]
        public async Task<bool> update_SpecificEvent_ReturnTrue()
        {
            var eventOriginal = await context.events.Where(ev => ev.id == 1).FirstOrDefaultAsync();
            eventOriginal.name = "name";
            var entries = await eventService.UpdateEvent(eventOriginal);
            var updatedEvent = await context.events.Where(ev => ev.id == 1).FirstOrDefaultAsync();
            Assert.That(eventOriginal.name, Is.EqualTo(updatedEvent.name));

            return entries > 0;

        }

        [Test]
        [TestCase(ExpectedResult = "Event test")]
        public async Task<string> add_NewEvent_ReturnNewEvent()
        {
            await eventService.AddEvent(eventDTO);
            var result = await context.events.Where(ev => ev.id == 13).FirstOrDefaultAsync();
            return result.name;
        }

        [Test]
        [TestCase(ExpectedResult = 12)]
        public async Task<int> getAllEvents_Return12()
        {
            // Right now there are 12 events being seeded in the ApplicationContext on the first edition
            var list = await  eventService.GetAllEvents(1);
            var result = list.Count();

            return result;
        }

        [Test]
        [TestCase(ExpectedResult = 0)]
        public async Task<int> getAllEvents_EmptyEdition_Returns0()
        {
            // Right now there are no events being seeded in the ApplicationContext on the second edition
            var list = await eventService.GetAllEvents(2);
            var result = list.Count();
            return result;
            
        }
        [Test]
        [TestCase(ExpectedResult = 0)]
        public async Task<int> getAllEvents_InvalidId_Returns0()
        {
            // This id doesnt exist in the ApplicationContext
            var list = await eventService.GetAllEvents(9921659);
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
