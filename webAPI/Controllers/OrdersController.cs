using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Dtos;
using WebAPI;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public OrdersController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<OrderDto> GetOrders()
        {
            return _mapper.Map<IEnumerable<OrderDto>>(_context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Manager)
                .Include(o => o.VacationPackage));
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return NotFound();

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, OrderInputDto order)
        {
            if (id != order.Id)
                return BadRequest();

            _context.Entry(_mapper.Map<Order>(order)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<OrderInputDto>> PostOrder(OrderInputDto order)
        {
            _context.Orders.Add(_mapper.Map<Order>(order));
            await _context.SaveChangesAsync();

            await new EmailService().SendMessageAsync(_context.Customers.FirstOrDefault(c => c.Id == order.CustomerId)?.Email, "У вас новая путевка!", "Время путешествий");

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        //[HttpPost]
        //public async Task SendTestEmail()
        //{
        //    await new EmailService().SendMessageAsync("", "У вас новая путевка!", "Время путешествий");
        //}

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
