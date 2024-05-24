using hotelAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace hotelAPI;

public class HotelContext : DbContext
{
    public HotelContext()
    {
    }

    public HotelContext(DbContextOptions<HotelContext> options) : base(options)
    {
    }
    
    public virtual DbSet<Hotel> Hotel { get; set; }
    public virtual DbSet<Order> Order { get; set; }
}