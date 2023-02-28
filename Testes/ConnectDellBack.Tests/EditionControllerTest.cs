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
        EditionDTO editionDTO;
        EditionModel editionModel;

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

            editionModel = new EditionModel()
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
            editionDTO = EditionDTO.ConvertModel2DTO(editionModel);
        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.AcceptedResult")]
        public async Task<String> HTTPGET_addEdition_ReturnOk()
        {
            ActionResult<IEnumerable<EditionDTO>> actionResult = await editionController.AddEdition(editionDTO);

            Console.WriteLine(actionResult);
            return actionResult.Result.ToString();
        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.AcceptedResult")]
        public async Task<String> HTTTPGET_updateEdition_ReturnOK()
        {
            editionModel.name = "updatedName";
            ActionResult<IEnumerable<EditionDTO>> actionResult = await editionController.UpdateEdition(editionModel);
            return actionResult.Result.ToString();

        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.OkObjectResult")]
        public async Task<String> HTTPGET_allEditionsNames_ReturnOk()
        {
            var actionResult = await editionController.GetEditionsNames(1);

            return actionResult.Result.ToString();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }


    }
}
