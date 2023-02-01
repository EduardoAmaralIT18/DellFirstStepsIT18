using ConnectDellBack.Controllers;
using ConnectDellBack.Services;
using ConnectDellBack.Models;
using Microsoft.AspNetCore.Mvc;
using ConnectDellBack.DTOs;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Microsoft.Extensions.Logging.Abstractions;

namespace ConnectDellBack.Tests
{
    [TestFixture]
    public class NewsControllerTest
    {
        private static DbContextOptions<ApplicationContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationContext>()
                                                                                .UseInMemoryDatabase(databaseName: "DbControllerTest")
                                                                                .Options;
        ApplicationContext context;
        NewsService newsService;
        NewsController newsController;

        [OneTimeSetUp]
        public void SetUp()
        {
            context = new ApplicationContext(dbContextOptions);
            context.Database.EnsureCreated();

            newsService = new NewsService(context);
            newsController = new NewsController(new NullLogger<NewsController>(), newsService);

        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.OkObjectResult")]
        public async Task<String> HTTPGET_GetNews_ReturnOk()
        {
            ActionResult<IEnumerable<NewsDTO>> actionResult = await newsController.GetNews();

            return actionResult.Result.ToString();
        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.OkResult")]
        public async Task<String> HTTPPOST_AddContent_ReturnOK()
        {
            var content = new ContentDTO()
            {
                title = "Title Test",
                text = "Text Test",
                author = 1,
                program = 1,
            };

            ActionResult actionResult = await newsController.AddContent(content);

            return actionResult.ToString();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }


    }
}