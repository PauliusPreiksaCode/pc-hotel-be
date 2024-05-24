namespace hotelAPI.DTOs;

public class EditHotelRequest : AddHotelRequest
{
    public required Guid Id { get; set; }
    
}