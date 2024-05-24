using hotelAPI.DTOs;
using hotelAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace hotelAPI.Services;

public class OrderService(HotelContext context, CalculationsService calculationsService)
{
    public async Task<List<Order>> GetAllOrders()
    {
        return await context.Order
            .Include(x => x.Hotel)
            .ToListAsync();
    }
    
    public Order GetOrderById(Guid id)
    {
        var order = context.Order.FirstOrDefault(x => x.Id.Equals(id));

        if (order is null)
        {
            throw new Exception("Order not found");
        }

        return order;
    }

    public async Task AddOrder(AddOrderRequest request)
    {
        var hotel = context.Hotel.FirstOrDefault(x => x.Id.Equals(request.HotelId));
        
        if (hotel is null)
        {
            throw new Exception("Hotel not found");
        }

        var price = calculationsService.calculatePrice(request.PeopleCount, request.PeopleCount, request.Breakfast, request.RoomType);
        
        var order = new Order
        {
            RoomType = request.RoomType,
            Breakfast = request.Breakfast,
            OrderDate = request.OrderDate,
            PeopleCount = request.PeopleCount,
            Period = request.Period,
            Price = price,
            Hotel = hotel
        };

        await context.AddAsync(order);
        await context.SaveChangesAsync();
    }

    public async Task UpdateOrder(EditOrderRequest request)
    {
        var order = context.Order.FirstOrDefault(x => x.Id.Equals(request.Id));
        
        if (order is null)
        {
            throw new Exception("Order not found");
        }
        
        var hotel = context.Hotel.FirstOrDefault(x => x.Id.Equals(request.HotelId));
        
        if (hotel is null)
        {
            throw new Exception("Hotel not found");
        }
        
        var price = calculationsService.calculatePrice(request.PeopleCount, request.PeopleCount, request.Breakfast, request.RoomType);

        order.RoomType = request.RoomType;
        order.Breakfast = request.Breakfast;
        order.OrderDate = request.OrderDate;
        order.PeopleCount = request.PeopleCount;
        order.Period = request.Period;
        order.Price = price;
        order.Hotel = hotel;

        await context.SaveChangesAsync();
    }

    public async Task DeleteOrder(Guid id)
    {
        var order = context.Order.FirstOrDefault(x => x.Id.Equals(id));
        
        if (order is null)
        {
            throw new Exception("Order not found");
        }

        context.Order.Remove(order);
        await context.SaveChangesAsync();
    }
}