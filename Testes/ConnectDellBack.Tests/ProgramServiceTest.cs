using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConnectDellBack.Models;
using NUnit.Framework;
using ConnectDellBack.Services;

namespace ConnectDellBack.Tests
{
    [TestFixture]
    internal class ProgramServiceTest
    {
        private static DbContextOptions<ApplicationContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationContext>()
                                                                                .UseInMemoryDatabase(databaseName: "DbTest")
                                                                                .Options;
        ApplicationContext context;
        ProgramService programService;

        [OneTimeSetUp]
        public void SetUp()
        {
            context = new ApplicationContext(dbContextOptions);
            context.Database.EnsureCreated();

            programService = new ProgramService(context);
        }

        [Test]
        [TestCase(ExpectedResult = 1)]
        public async Task<int> get_AllProgramsFromDB_ReturnProgramsCount()
        {
            var result = await programService.GetPrograms(1,0);

            return result.MyPrograms.Count;
        }

        [Test]
        [TestCase(ExpectedResult = true)]
        public async Task<bool> get_SpecificProgram_ReturnTrue()
        {
            var programExpected = context.programs.Where(prog => prog.id == 1).FirstOrDefault();

            var programServices = await programService.GetProgram(1);

            return programServices.Equals(programExpected);

        }

        [Test]
        [TestCase(ExpectedResult = true)]
        public async Task<bool> update_SpecificProgram_ReturnTrue()
        {
            var programOriginal = context.programs.Where(prog => prog.id == 1).FirstOrDefault();

            programOriginal.name = "novo nome para string";

            var entries = await programService.UpdateProgram(programOriginal);

            return entries > 0;

        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }



    }
}
