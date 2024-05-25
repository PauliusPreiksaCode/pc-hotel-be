using hotelAPI.DTOs;
using hotelAPI.Entities;

namespace hotelAPI.Services;

public interface IHotelService
{
    Task<List<Hotel>> GetAllHotels();
    Hotel GetHotelById(Guid id);
    Task AddHotel(AddHotelRequest request);
    Task UpdateHotel(EditHotelRequest request);
    Task DeleteHotel(Guid id);
}