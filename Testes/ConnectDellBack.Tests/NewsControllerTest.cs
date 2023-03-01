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
        ContentDTO content;       

        [OneTimeSetUp]
        public void SetUp()
        {
            context = new ApplicationContext(dbContextOptions);
            context.Database.EnsureCreated();

            newsService = new NewsService(context);
            newsController = new NewsController(new NullLogger<NewsController>(), newsService);

            content = new ContentDTO()
            {
                id = 1,
                title = "Title Test",
                text = "Text Test",
                author = 1,
                program = 1,
            };
        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.OkObjectResult")]
        public async Task<String> HTTPGET_GetNews_ReturnOk()
        {
            ActionResult<IEnumerable<NewsDTO>> actionResult = await newsController.GetNews();

            return actionResult.Result.ToString();
        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.AcceptedResult")]
        public async Task<String> HTTPPOST_AddContent_ReturnOK()
        {

            ActionResult actionResult = await newsController.AddContent(content);

            return actionResult.ToString();
        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.AcceptedResult")]
        public async Task<String> HTTPPOST_UpdateNews_ReturnOk()
        {
            content.title = "New title";
            ActionResult<NewsDTO> actionResult = await newsController.UpdateNews(content);

            return actionResult.Result.ToString();
        }

        [Test]
        [TestCase(ExpectedResult = "Microsoft.AspNetCore.Mvc.OkObjectResult")]
        public async Task<String> HTTPGET_GetSpecificNews_ReturnOk()
        {
            ActionResult<NewsDTO> actionResult = await newsController.GetSpecificNews(1);
            return actionResult.Result.ToString();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }


    }
}