using Microsoft.EntityFrameworkCore;

namespace foodOrder_api.Models;
public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options)
        : base(options)
    {
    }

    public DbSet<Products> Products { get; set; } = null!;
}