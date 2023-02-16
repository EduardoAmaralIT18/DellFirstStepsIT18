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
        EditionDTO edition;
        EditionModel model;

        [OneTimeSetUp]
        public void SetUp()
        {
            context = new ApplicationContext(dbContextOptions);
            context.Database.EnsureCreated();

            editionService = new EditionService(context);

            model = new EditionModel()
            {
                // ID is 8 since we already have 7 editions in the Application Context
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
            //EditionDTO.convertModel2DTO(model);
        }

        [Test]
        [TestCase(ExpectedResult = "Edition 99")]
        public async Task<string> add_NewEdition_ReturnNewEdition()
        {

            await editionService.addEdition(edition);

            var result = await context.editions.Where(ed => ed.id == 8).FirstOrDefaultAsync();

            return result.name;
        }

        [Test]
        public void update_FirstEdition_AssertEqual()
        {
            model.name = "Updated name";
            editionService.updateEdition(model);
            var editionUpdated = context.editions.Where(ed => ed.id == 8).FirstOrDefault();

            Mode workModeUpdated = (Mode)model.mode;

            Assert.That(editionUpdated.id, Is.EqualTo(model.id));
            Assert.That(editionUpdated.name, Is.EqualTo(model.name));
            Assert.That(editionUpdated.description, Is.EqualTo(model.description));
            Assert.That(editionUpdated.numberOfMembers, Is.EqualTo(model.numberOfMembers));
            Assert.That(editionUpdated.numberOfInterns, Is.EqualTo(model.numberOfInterns));
            Assert.That(editionUpdated.curriculum, Is.EqualTo(model.curriculum));
            Assert.That(editionUpdated.mode, Is.EqualTo(workModeUpdated));
        }

        //[Test]
        //public void checkEditionNames_AssertEqual()
        //{
        //    Task<IEnumerable<EditionDTO>> names = editionService.allEditions(1);

        //    Assert.That(names.ToString(), Is.EqualTo(""));
        //}


        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

    }
}