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
using Microsoft.AspNetCore.Http;

namespace ConnectDellBack.Tests
{
    [TestFixture]
    internal class NewsServiceTest
    {
        private static DbContextOptions<ApplicationContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationContext>()
                                                                                .UseInMemoryDatabase(databaseName: "DbTest")
                                                                                .Options;
        ApplicationContext context;
        NewsService newsService;

        [OneTimeSetUp]
        public void SetUp()
        {
            context = new ApplicationContext(dbContextOptions);
            context.Database.EnsureCreated();

            newsService = new NewsService(context);
        }

        [Test, Order(1)]
        [TestCase(ExpectedResult = 1)]
        public async Task<int> get_AllNewsFromDB_ReturnNewsCount()
        {
            var result = await newsService.getNews();

            return result.Count();
        }

        [Test, Order(2)]
        [TestCase(ExpectedResult = true)]
        public async Task<bool> AddContent_WithoutImage_ReturnTrue()
        {
            var content = new ContentDTO()
            {
                title = "Title Test",
                text = "Text Test",
                author = 1,
                program = 1,
            };
            
            var result = await newsService.addContent(content);

            return result;
        }

        [Test, Order(3)]
        [TestCase(ExpectedResult = true)]
        public async Task<bool> AddContent_WithImage_ReturnTrue()
        {
            byte[] image = File.ReadAllBytes("C:/Users/Larissa_Rosa/Documents/IT_Academy/01 - Projeto IT Academy/ConnectDellFull/Testes/ConnectDellBack.Tests/Assets/testImage.png");
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(image);
            writer.Flush();
            IFormFile file = new FormFile(stream, 0, stream.Length, "image", "TitleTestImage");

            var content = new ContentDTO()
            {
                title = "Title Test",
                text = "Text Test",
                author = 1,
                program = 1,
                image = file,
                imageName = "TitleTestImge"
            };
            
            var result = await newsService.addContent(content);

            return result;
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

    }
}
