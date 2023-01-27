using ConnectDellBack.Controllers;
using ConnectDellBack.Services;
using ConnectDellBack.Models;
using Microsoft.AspNetCore.Mvc;
using ConnectDellBack.DTOs;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ConnectDellBack.Tests
{
    [TestFixture]
    public class ProgramControllerTest
    {
        private static DbContextOptions<ApplicationContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationContext>()
                                                                                .UseInMemoryDatabase(databaseName: "DbControllerTest")
                                                                             .Options;
        ApplicationContext context;
        ProgramService programService;
        ProgramController programController;
        ProgramModel program;


        [OneTimeSetUp]
        public void Setup()
        {
            context = new ApplicationContext(dbContextOptions);
            context.Database.EnsureCreated();

            program = new ProgramModel()
            {
                id = 20,
                name = "Test",
                startDate = DateTime.Now,
                endDate = DateTime.Now,
                description = "test description"
            };


            programService = new ProgramService(context);
            programController = new ProgramController(new NullLogger<ProgramController>(), programService);
        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.OkResult")]
        public async Task<String> AddProgramToDBByController_ReturnTrue()
        {
            ActionResult<IEnumerable<ProgramModel>> actionResult = await programController.addProgram(program);
            return actionResult.Result.ToString();
        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.OkObjectResult")]
        public async Task<String> ShowBasicInfoByController_ReturnTrue()
        {
            ActionResult<ProgramInfoDTO> actionResult = await programController.showBasicInfo(20);
            return actionResult.Result.ToString();
        }

        [OneTimeTearDown] 
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }
    }
}
