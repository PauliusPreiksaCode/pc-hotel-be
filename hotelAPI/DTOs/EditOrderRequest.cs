using hotelAPI.Entities;
using hotelAPI.Enums;

namespace hotelAPI.DTOs;

public class EditOrderRequest : AddOrderRequest
{
    public required Guid Id { get; set; }
}