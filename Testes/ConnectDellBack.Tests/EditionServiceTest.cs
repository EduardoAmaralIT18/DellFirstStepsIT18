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


namespace ConnectDellBack.Tests
{
    [TestFixture]
    internal class EditionServiceTest
    {
        private static DbContextOptions<ApplicationContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationContext>()
                                                                                .UseInMemoryDatabase(databaseName: "DbTest")
                                                                                .Options;
        ApplicationContext context;
        EditionService editionService;
        EditionDTO editionDTO;
        EditionModel editionModel;

        [OneTimeSetUp]
        public void SetUp()
        {
            context = new ApplicationContext(dbContextOptions);
            context.Database.EnsureCreated();

            editionService = new EditionService(context);

            editionModel = new EditionModel()
            {
                id = 8,
                name = "Edition 99",
                startDate = new DateTime(2021, 10, 10),
                endDate = new DateTime(2022, 09, 10),
                description = "Sixteenth edition of the IT Academy program aimed at undergraduate students in computer science courses.",
                numberOfInterns = 20,
                mode = Mode.Remote,
                curriculum = "CSS, HTML, C#, JavaScript, SQL Server, Entity Framework, Asp.NET, Vue.js",
                program = context.programs.Where(prog => prog.id == 1).FirstOrDefault(),
                members = null
            };
            editionDTO = new EditionDTO()
            {
                id = 8,
                name = "Edition 99",
                startDate = new DateTime(2021, 10, 10),
                endDate = new DateTime(2022, 09, 10),
                description = "Sixteenth edition of the IT Academy program aimed at undergraduate students in computer science courses.",
                numberOfInterns = 20,
                mode = 1,
                curriculum = "CSS, HTML, C#, JavaScript, SQL Server, Entity Framework, Asp.NET, Vue.js",
                program = 1,
                members = null
            };
            //editionDTO = EditionDTO.ConvertModel2DTO(editionModel);
        }

        [Test]
        [TestCase(ExpectedResult = "Edition 99")]
        public async Task<string> add_NewEdition_ReturnNewEdition()
        {

            await editionService.AddEdition(editionDTO);

            var result = await context.editions.Where(ed => ed.id == 8).FirstOrDefaultAsync();

            return result.name;
        }



        [Test]
        [TestCase(ExpectedResult = true)]
        public async Task<bool> update_FirstEdition_AssertEqual()
        {
            var originalEdition = await context.editions.Where(ed => ed.id == 1).FirstOrDefaultAsync();
            var aux = originalEdition;
            aux.name = "Updated name";
            var entries = await editionService.UpdateEdition(aux);
            var editionUpdated = await context.editions.Where(ed => ed.id == 1).FirstOrDefaultAsync();

            Mode workModeUpdated = (Mode)originalEdition.mode;

            Assert.That(editionUpdated.id, Is.EqualTo(originalEdition.id));
            Assert.That(editionUpdated.name, Is.EqualTo(originalEdition.name));
            Assert.That(editionUpdated.description, Is.EqualTo(originalEdition.description));
            Assert.That(editionUpdated.numberOfInterns, Is.EqualTo(originalEdition.numberOfInterns));
            Assert.That(editionUpdated.curriculum, Is.EqualTo(originalEdition.curriculum));
            Assert.That(editionUpdated.mode, Is.EqualTo(workModeUpdated));

            return entries > 0;
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

    }
}