using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCoreApi21Test1.Models;

namespace WebCoreApi21Test1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private eSUNHousingContext _context;
        public ValuesController(eSUNHousingContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            var result = _context.Account.ToList();

            return result;
        }

        /// <summary>
        /// GET api/values/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Account> Get(string id)
        {
            var result = _context.Account
                .Where(c => c.UserId==id)
                .ToList();

            Account account = result.FirstOrDefault();

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(201)]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
