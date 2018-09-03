using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCoreApi21Test1.Models;

namespace WebCoreApi21Test1.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomerDetailsController : Controller
    {
        private readonly eSUNHousingContext _context;

        public CustomerDetailsController(eSUNHousingContext context)
        {
            _context = context;
        }

        // GET: api/CustomerDetails
        [HttpGet]
        public IEnumerable<CustomerDetail> GetCustomerDetail()
        {
            return _context.CustomerDetail;
        }

        // GET: api/CustomerDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerDetail([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerDetail = await _context.CustomerDetail.FindAsync(id);

            if (customerDetail == null)
            {
                return NotFound();
            }

            return Ok(customerDetail);
        }

        // PUT: api/CustomerDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerDetail([FromRoute] long id, [FromBody] CustomerDetail customerDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerDetail.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customerDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CustomerDetails
        [HttpPost]
        public async Task<IActionResult> PostCustomerDetail([FromBody] CustomerDetail customerDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CustomerDetail.Add(customerDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerDetail", new { id = customerDetail.CustomerId }, customerDetail);
        }

        // DELETE: api/CustomerDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerDetail([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerDetail = await _context.CustomerDetail.FindAsync(id);
            if (customerDetail == null)
            {
                return NotFound();
            }

            _context.CustomerDetail.Remove(customerDetail);
            await _context.SaveChangesAsync();

            return Ok(customerDetail);
        }

        private bool CustomerDetailExists(long id)
        {
            return _context.CustomerDetail.Any(e => e.CustomerId == id);
        }
    }
}