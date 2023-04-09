using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Order order, [FromServices] AppDbContext db)
        {
            var volume1 = new Volume
            {
                Pieces = 13,
                Weight = 5,
                Lenght = 2,
                Width = 34,
                Height = 4,
                OrderId = "00001"

            };
            var volume2 = new Volume
            {
                Pieces = 1,
                Weight = 3,
                Lenght = 20,
                Width = 4,
                Height = 11,
                OrderId = "00001"

            };
            var volume3 = new Volume
            {
                Pieces = 5,
                Weight = 4,
                Lenght = 3,
                Width = 2,
                Height = 1,
                OrderId = "00002"

            };



            var order1 = new Order
            {
                OrderId = "00001",
                OriginPointCode = "Teste1",
                OriginPartnerPointCode = "Teste1",
                OriginPostalCode = "Teste1",
                CompanyId = 1,
                Volumes = new List<Volume>
                {
                    volume1,
                    volume2
                }
                
            };

            var order2 = new Order
            {
                OrderId = "00002",
                OriginPointCode = "Teste2",
                OriginPartnerPointCode = "Teste2",
                OriginPostalCode = "Teste2",
                CompanyId = 1,
                Volumes = new List<Volume>
                {
                    volume3                    
                }

            };

            var orderXX = new List<Order> { order1, order2 };

            await db.Orders.AddRangeAsync(orderXX);
            await db.SaveChangesAsync();

            return Created($"/orders/{order.OrderId}", order);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] AppDbContext db)
        {
            var orders = await db.Orders
                .Include(x => x.Volumes)
                .ToListAsync();

            return Ok(orders);
        }
        
    }
}
