namespace hotelAPI.DTOs;

public class AddHotelRequest
{
    public required string Name { get; set; }
    
    public required string Location { get; set; }

    public required string Photo { get; set; } 
}