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
        EditionDTO modelUpdate;

        [OneTimeSetUp]
        public void SetUp()
        {
            context = new ApplicationContext(dbContextOptions);
            context.Database.EnsureCreated();

            editionService = new EditionService(context);

            modelUpdate = new EditionDTO()
            {
                id = 2,
                name = "Test",
                startDate = DateTime.Now,
                endDate = DateTime.Now,
                description = "Testing the database",
                numberOfInterns = 3,
                mode = 2,
                curriculum = "Test",
                program = 1
            };

            model = new EditionModel()
            {
                id = 2,
                name = "Edi��o 16",
                startDate = new DateTime(2021, 10, 10),
                endDate = new DateTime(2022, 09, 10),
                description = "Sixteenth edition of the IT Academy program aimed at undergraduate students in computer science courses.",
                numberOfInterns = 20,
                mode = Mode.Remote,
                curriculum = "CSS, HTML, C#, JavaScript, SQL Server, Entity Framework, Asp.NET, Vue.js",
                program = context.programs.Where(prog => prog.id == 1).FirstOrDefault()
            };

            edition = EditionDTO.convertModel2DTO(model);
        }

        [Test]
        public void add_NewEdition_ReturnNewEdition()
        {

            editionService.addEdition(edition);


            //Assert.AreEqual(expectedStudent, st2);

            EditionDTO result = EditionDTO.convertModel2DTO(
                         context.editions.Where(ed => ed.id == 2).FirstOrDefault());

            Assert.That(result.name, Is.EqualTo(edition.name));
        }

        [Test]
        public void update_FirstEdition_AssertEqual()
        {
            editionService.updateEdition(modelUpdate);
            var editionUpdated = context.editions.Where(ed => ed.id == 2).FirstOrDefault();

            Mode workModeUpdated = (Mode)modelUpdate.mode;

            Assert.That(editionUpdated.id, Is.EqualTo(modelUpdate.id));
            Assert.That(editionUpdated.name, Is.EqualTo(modelUpdate.name));
            Assert.That(editionUpdated.description, Is.EqualTo(modelUpdate.description));
            Assert.That(editionUpdated.numberOfInterns, Is.EqualTo(modelUpdate.numberOfInterns));
            Assert.That(editionUpdated.curriculum, Is.EqualTo(modelUpdate.curriculum));
            Assert.That(editionUpdated.mode, Is.EqualTo(workModeUpdated));
        }

        // [Test]
        // public async void checkEditionNames_AssertEqual()
        // {
        //     Task<IEnumerable<EditionDTO>> names = editionService.allEditions(1);

        //     Assert.That(names.ToString(), Is.EqualTo(""));
        // }


        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

    }
}