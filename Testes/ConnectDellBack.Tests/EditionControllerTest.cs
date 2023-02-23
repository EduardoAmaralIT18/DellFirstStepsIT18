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
    public class EditionControllerTest
    {
        private static DbContextOptions<ApplicationContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationContext>()
                                                                                .UseInMemoryDatabase(databaseName: "DbControllerTest")
                                                                                .Options;
        ApplicationContext context;
        EditionService editionService;
        EditionController editionController;
        EditionDTO edition;
        EditionModel model;

        [OneTimeSetUp]
        public void SetUp()
        {
            context = new ApplicationContext(dbContextOptions);
            context.Database.EnsureCreated();

            editionService = new EditionService(context);
            editionController = new EditionController(new NullLogger<EditionController>(), editionService);

            ProgramModel prog = new ProgramModel()
            {
                id = 1,
                name = "TestProgram",
                startDate = DateTime.Now,
                description = "Test description"
            };

            model = new EditionModel()
            {
                id = 1,
                name = "Test",
                startDate = DateTime.Now,
                endDate = DateTime.Now,
                description = "Testing the database",
                numberOfInterns = 1,
                mode = Mode.InOffice,
                curriculum = "vue :c",
                program = prog
            };
            edition = EditionDTO.convertModel2DTO(model);
        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.OkResult")]
        public async Task<String> HTTPGET_addEdition_ReturnOk()
        {
            ActionResult<IEnumerable<EditionDTO>> actionResult = await editionController.addEdition(edition);

            Console.WriteLine(actionResult);
            return actionResult.Result.ToString();
        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.OkResult" )]
        public async Task<String> HTTTPGET_updateEdition_ReturnOK()
        {
            ActionResult<IEnumerable<EditionDTO>> actionResult = await editionController.updateEdition(edition);

            Console.WriteLine(actionResult);
            return actionResult.Result.ToString();
        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.OkResult" )]
        public async Task<String> HTTPGET_allEditionsNames_ReturnOk() {
            ActionResult<IEnumerable<EditionDTO>> actionResult = WaitCallback editionController.getEditionsNames(1);

            return actionResult.Result.ToString();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }


    }
}
