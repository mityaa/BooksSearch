using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.Extensions.Logging;

namespace BookSearchFront.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IBookService _bookService = new BookService();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<JsonDocument> Get(string word)
        {
            var result = await _bookService.SearchBooksByWord(word);
            var json = JsonSerializer.SerializeToDocument(result);
            return json;
        }
    }
}
