using hotelAPI.DTOs;
using hotelAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace hotelAPI.Services;

public class HotelService(HotelContext context)
{
    public async Task<List<Hotel>> GetAllHotels()
    {
        var hotels = await context.Hotel.ToListAsync();
        return hotels;
    }

    public Hotel GetHotelById(Guid id)
    {
        var hotel = context.Hotel.FirstOrDefault(x => x.Id.Equals(id));

        if (hotel is null)
        {
            throw new Exception("Hotel not found");
        }

        return hotel;
    }

    public async Task AddHotel(AddHotelRequest request)
    {
        var hotel = new Hotel
        {
            Name = request.Name,
            Location = request.Location,
            Photo = request.Photo
        };

        await context.Hotel.AddAsync(hotel);
        await context.SaveChangesAsync();
    }

    public async Task UpdateHotel(EditHotelRequest request)
    {
        var hotel = context.Hotel.FirstOrDefault(x => x.Id.Equals(request.Id));

        if (hotel is null)
        {
            throw new Exception("Hotel not found");
        }

        hotel.Name = request.Name;
        hotel.Location = request.Location;
        hotel.Photo = request.Photo;

        await context.SaveChangesAsync();
    }

    public async Task DeleteHotel(Guid id)
    {
        var hotel = context.Hotel.FirstOrDefault(x => x.Id.Equals(id));
        
        if (hotel is null)
        {
            throw new Exception("Hotel not found");
        }

        var orders = await context.Order
            .Include(x => x.Hotel)
            .ToListAsync();

        var hotelIsBooked = orders.Any(order => order.Hotel.Id.Equals(hotel.Id));

        if (hotelIsBooked)
        {
            throw new Exception("Hotel is booked");
        }

        context.Hotel.Remove(hotel);
        await context.SaveChangesAsync();
    }
}