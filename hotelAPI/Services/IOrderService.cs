using hotelAPI.DTOs;
using hotelAPI.Entities;

namespace hotelAPI.Services;

public interface IOrderService
{
    Task<List<Order>> GetAllOrders();
    Order GetOrderById(Guid id);
    Task AddOrder(AddOrderRequest request);
    Task UpdateOrder(EditOrderRequest request);
    Task DeleteOrder(Guid id);
}