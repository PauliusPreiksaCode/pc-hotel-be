using hotelAPI.DTOs;
using hotelAPI.Enums;

namespace hotelAPI.Services;

public interface ICalculationsService
{
    decimal CalculatePrice(GetPriceRequest request);
    decimal CalculatePrice(int peopleCount, int period, bool breakfast, RoomType roomType);
}