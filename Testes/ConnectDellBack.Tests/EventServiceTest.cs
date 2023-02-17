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
                id = 2,
                name = "Edi��o 16",
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
                id = 1,
                name = "Event test",
                phaseType = PhaseType.HandsOn,
                eventType = EventType.Activity,
                startDate = DateTime.Now,
                endDate = DateTime.Now,
                where = "remote",
                //peopleinvolved = ???
                edition = modelToEvent

            };

            eventDTO = EventDTO.convertModel2DTO(evnt);
        }

        [Test]
        public void update_FirstEvent_AssertEqual()
        {
            eventService.updateEvent(modelUpdate);
            var eventUpdated = context.events.Where(ev => ev.id == 2).FirstOrDefault();

            Mode workModeUpdated = (Mode)modelUpdate.mode;

            Assert.That(eventUpdated.id, Is.EqualTo(modelUpdate.id));
            Assert.That(eventUpdated.name, Is.EqualTo(modelUpdate.name));
            Assert.That(eventUpdated.phaseType, Is.EqualTo(modelUpdate.phaseType));
            Assert.That(eventUpdated.eventType, Is.EqualTo(modelUpdate.eventType));
            Assert.That(eventUpdated.startDate, Is.EqualTo(modelUpdate.startDate));
            Assert.That(eventUpdated.endDate, Is.EqualTo(modelUpdate.endDate));
            Assert.That(eventUpdated.where, Is.EqualTo(modelUpdate.where));
            //Assert.That(eventUpdated.peopleInvolved Is.EqualTo(modelUpdate.curriculum));
        }


        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }



    }
}
