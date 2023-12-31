﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConnectDellBack.Models;
using NUnit.Framework;
using ConnectDellBack.Services;
using ConnectDellBack.DTOs;
using System.Runtime.CompilerServices;

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
        ProgramModel program;
        ProgramInfoDTO programDTO;

        [OneTimeSetUp]
        public void SetUp()
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
            programDTO = ProgramInfoDTO.ConvertModel2DTONoPermission(program);
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
        public void addProgramToDB_ReturnTrue()
        {
            programService.AddProgram(program);
            var result = context.programs.Where(progra => progra.id == 20)
                                          .FirstOrDefault();
            Assert.That(result.name, Is.EqualTo(program.name));
        }

        [Test]
        [TestCase(ExpectedResult = "Test")]
        public async Task<String> getProgramInfoNoPermissionFromDBAsDTO_ReturnTrue()
        {
            ProgramInfoDTO program = await programService.GetProgramInfoNoPermission(20);

            return program.name;
        }



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
