using hotelAPI.Enums;

namespace hotelAPI.DTOs;

public class GetPriceRequest
{
    public required RoomType RoomType { get; set; }
    
    public required bool Breakfast { get; set; }
    
    public required int PeopleCount { get; set; }
    
    public required int Period { get; set; }
}