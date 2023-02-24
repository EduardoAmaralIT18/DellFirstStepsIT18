using ConnectDellBack.Controllers;
using ConnectDellBack.Services;
using ConnectDellBack.Models;
using ConnectDellBack.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Microsoft.Extensions.Logging.Abstractions;

namespace ConnectDellBack.Tests
{
    [TestFixture]
    public class EventControllerTest
    {
        private static DbContextOptions<ApplicationContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationContext>()
                                                                                .UseInMemoryDatabase(databaseName: "DbControllerTest")
                                                                                .Options;
        ApplicationContext context;
        EventService eventService;
        EventController eventController;
        EventDTO evnt;
        EventsModel model;

        [OneTimeSetUp]
        public void SetUp()
        {
            context = new ApplicationContext(dbContextOptions);
            context.Database.EnsureCreated();

            eventService = new EventService(context);
            eventController = new EventController(new NullLogger<EventController>(), eventService);

        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.OkObjectResult")]
        public async Task<String> HTTPGET_GetEventToUpdate_ReturnOk()
        {
            ActionResult<EventDTO> actionResult = await eventController.getEventToUpdate(1);
            return actionResult.Result.ToString();
        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.OkResult")]
        public async Task<String> HTTPPOST_updateEvent_ReturnTrue()
        {
            var eventOriginal = context.events.Where(ev => ev.id == 1).FirstOrDefault();
            eventOriginal.name = "event";
            ActionResult result = await eventController.updateEvent(eventOriginal);

            return result.ToString();
        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.OkResult")]
        public async Task<String> HTTPGET_addEvent_ReturnOk()
        {
            evnt = new EventDTO() {name = "name",
                                    phaseType = PhaseType.Set_Up,
                                    eventType = EventType.Activity,
                                    startDate = DateTime.Now,
                                    endDate = DateTime.Now,
                                    where = "casa nelson",
        };
            ActionResult<IEnumerable<EventDTO>> actionResult = await eventController.addEvent(evnt);
        }
        public async Task<String> HTTPGET_getAllEvents_ReturnOk()
        {
            ActionResult<IEnumerable<EventDTO>> actionResult = await eventController.getAllEvents(1);

            Console.WriteLine(actionResult);
            return actionResult.Result.ToString();
        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.NoContentResult")]
        public async Task<String> HTTPGET_getAllEvents_EditionWithoutEvents_ReturnNoContentResult()
        {
            var actionResult = await eventController.getAllEvents(2);

            Console.WriteLine(actionResult);
            return actionResult.Result.ToString();
        }
        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.NoContentResult")]
        public async Task<String> HTTPGET_getAllEvents_InvalidId_ReturnNoContentResult()
        {
            ActionResult<IEnumerable<EventDTO>>? actionResult = await eventController.getAllEvents(-1);

            Console.WriteLine(actionResult);
            return actionResult.Result.ToString();
        }



        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }


    }
}
