using hotelAPI.Entities;
using hotelAPI.Enums;

namespace hotelAPI.DTOs;

public class AddOrderRequest
{
    
    public required RoomType RoomType { get; set; }
    
    public required bool Breakfast { get; set; }
    
    public required DateTime OrderDate { get; set; }
    
    public required int PeopleCount { get; set; }
    
    public required int Period { get; set; }
    
    public required Guid HotelId { get; set; }
}