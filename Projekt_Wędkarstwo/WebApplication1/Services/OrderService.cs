using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class OrderService: IOrderService
    {
        public readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }



        public async Task<OrderResponseDto> CreateOrderAsync(CreateOrderDto dto, ClaimsPrincipal userClaims)
        {
            var email = userClaims.FindFirstValue(ClaimTypes.Email);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if(user == null)
            {
                throw new Exception("User not found");
            }

            var productIds = dto.Items.Select(i => i.ProductId).ToList();

            var products = await _context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();

            decimal totalPrice = 0;

            var orderItems = new List<OrderItem>();

            foreach (var item in dto.Items)
            {
                var product = products.FirstOrDefault(p => p.Id == item.ProductId);

                if (product == null)
                {
                    throw new InvalidOperationException($"Product with ID {item.ProductId} not found");
                   
                }

                if (product.Stock < item.Quantity)
                {
                    throw new InvalidOperationException($"Not enough stock for product {product.Name}");
                }

                totalPrice += product.Price * item.Quantity;

                orderItems.Add(new OrderItem
                {
                    ProductId = product.Id,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                });

                product.Stock -= item.Quantity;
            }

            var order = new Order
            {
                UserId = user.Id,
                TotalPrice = totalPrice,
                CreatedAt = DateTime.UtcNow,
                Status = "Pending",
                OrderItems = orderItems
            };

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            return new OrderResponseDto
            {
                OrderId = order.Id,
                CreatedAt = order.CreatedAt,
                Status = order.Status,
                TotalPrice = order.TotalPrice
            };
            
        }
    }
}
