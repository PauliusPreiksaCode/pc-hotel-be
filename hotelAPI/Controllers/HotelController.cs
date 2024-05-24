using hotelAPI.DTOs;
using hotelAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace hotelAPI.Controllers;

[Route("hotel")]
public class HotelController(HotelService hotelService) : ControllerBase
{
    [HttpGet]
    [Route("list")]
    public async Task<IActionResult> GetAllHotels()
    {
        try
        {
            var hotels = await hotelService.GetAllHotels();
            return Ok(hotels);
        }
        catch (Exception e)
        {
            return e.Message switch
            {
                _ => StatusCode(500, "Error occured while getting hotels")
            };
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetHotelById([FromQuery] Guid id)
    {
        try
        {
            var hotel = hotelService.GetHotelById(id);
            return Ok(hotel);
        }
        catch (Exception e)
        {
            return e.Message switch
            {
                "Hotel not found" => NotFound("Hotel not found"),
                _ => StatusCode(500, "Error occured while getting hotel")
            };
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> AddHotel([FromBody] AddHotelRequest request)
    {
        try
        {
            await hotelService.AddHotel(request);
            return Ok();
        }
        catch (Exception e)
        {
            return e.Message switch
            {
                _ => StatusCode(500, "Error occured while adding hotel")
            };
        }
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateHotel([FromBody] EditHotelRequest request)
    {
        try
        {
            await hotelService.UpdateHotel(request);
            return Ok();
        }
        catch (Exception e)
        {
            return e.Message switch
            {
                "Hotel not found" => NotFound("Hotel not found"),
                _ => StatusCode(500, "Error occured while updating hotel")
            };
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteHotel([FromQuery] Guid id)
    {
        try
        {
            await hotelService.DeleteHotel(id);
            return Ok();
        }
        catch (Exception e)
        {
            return e.Message switch
            {
                "Hotel not found" => NotFound("Hotel not found"),
                _ => StatusCode(500, "Error occured while deleting hotel")
            };
        }
    }
}