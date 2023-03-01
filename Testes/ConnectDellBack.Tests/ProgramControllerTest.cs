using ConnectDellBack.Controllers;
using ConnectDellBack.Services;
using ConnectDellBack.Models;
using Microsoft.AspNetCore.Mvc;
using ConnectDellBack.DTOs;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Runtime.InteropServices;

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
        [OneTimeSetUp]
        public void SetUp()
        {
            context = new ApplicationContext(dbContextOptions);
            context.Database.EnsureCreated();
            programService = new ProgramService(context);
            programController = new ProgramController(new NullLogger<ProgramController>(), programService);
        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.OkObjectResult")]
        public async Task<String> HTTPGET_GetProgram_ReturnOk()
        {
            ActionResult<ProgramModel> actionResult = await programController.GetProgram(1);
            return actionResult.Result.ToString();
        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.OkResult")]
        public async Task<String> HTTPPOST_UpdateSpecificProgram_ReturnTrue()
        {
            var programOriginal = context.programs.Where(prog => prog.id == 1).FirstOrDefault();

            programOriginal.name = "novo nome para string";

            ActionResult result = await programController.UpdateProgram(programOriginal);

            return result.ToString();
        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.OkObjectResult")]
        public async Task<String> HTTPGET_GetPrograms_ReturnOk()
        {
            ActionResult<ProgramDTO> actionResult = await programController.GetPrograms(1, 0);
            return actionResult.Result.ToString();
        }

        public async Task<String> ShowBasicInfoByController_ReturnTrue()
        {
            ActionResult<ProgramInfoDTO> actionResult = await programController.ShowBasicInfo(20);
            return actionResult.Result.ToString();
        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.OkObjectResult")]
        public async Task<String> HTTPGET_GetProgramsName_ReturnOk()
        {
            ActionResult<IEnumerable<ProgramInfoDTO>> actionResult = await programController.GetProgramsName();

            return actionResult.Result.ToString();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }
    }

}

