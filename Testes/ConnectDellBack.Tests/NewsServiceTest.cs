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
        ContentDTO content;

        [OneTimeSetUp]
        public void SetUp()
        {
            context = new ApplicationContext(dbContextOptions);
            context.Database.EnsureCreated();

            newsService = new NewsService(context);
            
            content = new ContentDTO()
            {
                id = 1,
                title = "Title Test",
                text = "Text Test",
                author = 1,
                program = 1,
            };
        }

        [Test, Order(1)]
        [TestCase(ExpectedResult = 1)]
        public async Task<int> get_AllNewsFromDB_ReturnNewsCount()
        {
            var result = await newsService.GetNews();

            return result.Count();
        }

        [Test, Order(2)]
        [TestCase(ExpectedResult = true)]
        public async Task<bool> AddContent_WithoutImage_ReturnTrue()
        {
            var result = await newsService.AddContent(content);

            return result;
        }

        [Test, Order(3)]
        [TestCase(ExpectedResult = true)]
        public async Task<bool> AddContent_WithImage_ReturnTrue()
        {
            byte[] image = File.ReadAllBytes("../../../Assets/testImage.png");
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(image);
            writer.Flush();
            IFormFile file = new FormFile(stream, 0, stream.Length, "image", "TitleTestImage");

            content.image = file;
            content.imageName = "TitleTestImge";
            
            var result = await newsService.AddContent(content);

            return result;
        }

        [TestCase(ExpectedResult = "TestingTitle123")]
        public async Task<string> AddContent_WithoutImage_UpdatesTitle()
        {
            var aux = await context.news.Where(news => news.id == 1).FirstOrDefaultAsync();
            aux.title = "TestingTitle123";

            var resultNewsModel = await context.news.Where(news => news.id == 1).FirstOrDefaultAsync();

            var result = resultNewsModel.title;
            
            return result;
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

    }
}
