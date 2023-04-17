using EntityFramework_Slider.Data;
using EntityFramework_Slider.Models;
using EntityFramework_Slider.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_Slider.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context, IBasketService basketService)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
           return await _context.Products.Include(m => m.Images).Where(m => !m.SoftDelete).ToListAsync();
        }

        public async Task<Product> GetById(int? id)
        {
           return await _context.Products.FindAsync(id);
        }
    }
}
