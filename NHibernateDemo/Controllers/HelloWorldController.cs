using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHibernateDemo.Entity;

namespace NHibernateDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        private readonly ILogger<HelloWorldController> _logger;
        private readonly IMapperSession _session;


        public HelloWorldController(ILogger<HelloWorldController> logger, IMapperSession session)
        {
            _logger = logger;
            _session = session;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var books = _session.Books.ToList();
            return Ok(books);
        }

        [HttpGet]
        [Route("1")]
        public IActionResult Index1()
        {
            var books = _session.Books
                                .Where(b => b.Title.StartsWith("How to"))
                                .ToList();

            return Ok(books);
        }
    }
}
