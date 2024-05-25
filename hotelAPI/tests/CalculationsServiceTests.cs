using hotelAPI.DTOs;
using hotelAPI.Enums;
using hotelAPI.Services;
using Xunit;

namespace hotelAPI.tests;

public class CalculationsServiceTests
{
    private readonly CalculationsService _calculationsService = new();

    [Fact]
        public void CalculatePrice_ValidInputs_ReturnsExpectedPrice()
        {
            int peopleCount = 2;
            int period = 3;
            bool breakfast = true;
            RoomType roomType = RoomType.Deluxe;
            decimal expectedPrice = (150 * period) + (15 * peopleCount * period) + 20;

            decimal actualPrice = _calculationsService.calculatePrice(peopleCount, period, breakfast, roomType);

            Assert.Equal(expectedPrice, actualPrice);
        }

        [Fact]
        public void CalculatePrice_NegativePeriod_ThrowsException()
        {
            int peopleCount = 2;
            int period = -1;
            bool breakfast = true;
            RoomType roomType = RoomType.Standard;

            var exception = Assert.Throws<Exception>(() => _calculationsService.calculatePrice(peopleCount, period, breakfast, roomType));
            
            Assert.Equal("Values should not be negative", exception.Message);
        }

        [Fact]
        public void CalculatePrice_NegativePeopleCount_ThrowsException()
        {
            int peopleCount = -1;
            int period = 3;
            bool breakfast = false;
            RoomType roomType = RoomType.Suite;

            var exception = Assert.Throws<Exception>(() => _calculationsService.calculatePrice(peopleCount, period, breakfast, roomType));
            
            Assert.Equal("Values should not be negative", exception.Message);
        }

        [Fact]
        public void CalculatePrice_InvalidRoomType_ThrowsArgumentOutOfRangeException()
        {
            int peopleCount = 2;
            int period = 3;
            bool breakfast = false;
            RoomType roomType = (RoomType)999; // Invalid room type

            Assert.Throws<ArgumentOutOfRangeException>(() => _calculationsService.calculatePrice(peopleCount, period, breakfast, roomType));
        }

        [Fact]
        public void CalculatePrice_ValidRequestObject_ReturnsExpectedPrice()
        {
            var request = new GetPriceRequest
            {
                PeopleCount = 1,
                Period = 2,
                Breakfast = true,
                RoomType = RoomType.Standard
            };
            decimal expectedPrice = (100 * request.Period) + (15 * request.PeopleCount * request.Period) + 20;

            decimal actualPrice = _calculationsService.calculatePrice(request);

            Assert.Equal(expectedPrice, actualPrice);
        }
}