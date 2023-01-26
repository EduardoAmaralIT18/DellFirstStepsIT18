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
                name = "Test",
                startDate = DateTime.Now,
                endDate = DateTime.Now,
                description = "Testing the database",
                numberOfMembers = 1,
                numberOfInterns = 1,
                mode = Mode.InOffice,
                curriculum = "vue :c",
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
        
        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

    }
}
