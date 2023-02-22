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
        
        EventsModel evnt;
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
                numberOfMembers = 25,
                numberOfInterns = 20,
                mode = Mode.Remote,
                curriculum = "CSS, HTML, C#, JavaScript, SQL Server, Entity Framework, Asp.NET, Vue.js",
                program = context.programs.Where(prog => prog.id == 1).FirstOrDefault()
            };

            evnt = new EventsModel()
            {
                id = 2,
                name = "Event test",
                phaseType = PhaseType.HandsOn,
                eventType = EventType.Activity,
                startDate = DateTime.Now,
                endDate = DateTime.Now,
                where = "remote",
                peopleInvolved = null,
                edition = modelToEvent

            };

            eventDTO = EventDTO.convertModel2DTO(evnt);
        }


        [Test]
        [TestCase(ExpectedResult = true)]
        public async Task<bool> GetEventUpdated_ReturnTrue()
        {
            var eventExpected = context.events.Where(ev => ev.id == 2).FirstOrDefault();

            var eventServices = await eventService.getEvent(2);

            Console.WriteLine(eventExpected + "-----------------------EVENT EXPECTED----------------------");
            Console.WriteLine(eventServices + "-----------------------EVENT SERVICE-------------------------");
            return eventServices.Equals(eventExpected);


        }


        [Test]
        [TestCase(ExpectedResult = true)]
        public async Task<bool> update_FirstEvent_AssertEqual()
        {
            evnt.name = "updatedName";
            await eventService.updateEvent(evnt);
            var eventUpdated = context.events.Where(ev => ev.id == 2).FirstOrDefault();

            return eventUpdated.Equals(eventDTO);

            // Assert.That(eventUpdated.id, Is.EqualTo(eventDTO.id));
            // Assert.That(eventUpdated.name, Is.EqualTo(eventDTO.name));
            // Assert.That(eventUpdated.phaseType, Is.EqualTo(eventDTO.phaseType));
            // Assert.That(eventUpdated.eventType, Is.EqualTo(eventDTO.eventType));
            // Assert.That(eventUpdated.startDate, Is.EqualTo(eventDTO.startDate));
            // Assert.That(eventUpdated.endDate, Is.EqualTo(eventDTO.endDate));
            // Assert.That(eventUpdated.where, Is.EqualTo(eventDTO.where));

        }


        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }



    }
}
