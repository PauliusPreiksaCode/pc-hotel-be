using hotelAPI.Enums;

namespace hotelAPI.Entities;

public class Order
{
    public Guid Id { get; set; }
    
    public RoomType RoomType { get; set; }
    
    public bool Breakfast { get; set; }
    
    public DateTime OrderDate { get; set; }
    
    public int PeopleCount { get; set; }
    
    public int Period { get; set; }
    
    public decimal Price { get; set; }
    
    public required Hotel Hotel { get; set; }
}