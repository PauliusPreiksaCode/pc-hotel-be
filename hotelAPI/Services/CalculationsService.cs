using hotelAPI.DTOs;
using hotelAPI.Enums;

namespace hotelAPI.Services;

public class CalculationsService
{
    public decimal calculatePrice(int peopleCount, int period, bool breakfast, RoomType roomType)
    {
        const decimal cleaningFee = 20;
        const decimal breakfastPrice = 15;

        decimal totalCost = 0;

        switch (roomType)
        {
            case RoomType.Suite:
                totalCost += 200 * period;
                break;
            case RoomType.Deluxe:
                totalCost += 150 * period;
                break;
            case RoomType.Standard:
                totalCost += 100 * period;
                break;
        }

        if (breakfast)
        {
            totalCost += breakfastPrice * peopleCount * period;
        }
        
        totalCost += cleaningFee;

        return totalCost;
    }

    public decimal calculatePrice(GetPriceRequest request)
    {
        return calculatePrice(request.PeopleCount, request.Period, request.Breakfast, request.RoomType);
    }
}