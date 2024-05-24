using hotelAPI.Entities;

namespace hotelAPI.Seeders;

public static class HotelSeeder
{
    public static void Seed(HotelContext context)
    {
        context.Database.EnsureCreated();
        
        var hotels = new List<Hotel>
        {
            new Hotel
            {
                Name = "Radisson",
                Location = "Kaunas",
                Photo =
                    "https://lh3.googleusercontent.com/p/AF1QipOEhFrgkb2zVo0NyEMc_sY9QXH-lAPd3IJnUqd3=s1360-w1360-h1020-rw"
            },
            new Hotel
            {
                Name = "Esė Hotel SPA",
                Location = "Birštonas",
                Photo =
                    "https://lh3.googleusercontent.com/gps-proxy/ALd4DhHUhfrHksgg9lfP-KQ98914lfrI2qJ6nNepEskML2JXq5oxCZ_ZgTgmYeYqN4RqOavNihHNTXjUxRIGgrrAtu7DcksNUgsIIhv-3y0YeEBzBFFDy9DzSLaVtMAHFRhNJ3F2Z4KaBU1h_-Jkw7CSBTiVkxZQjGxfO4ldt1DBX7AC7BP7bjL_ZeMICg=s1360-w1360-h1020-rw"
            },
            new Hotel
            {
                Name = "Domus Maria",
                Location = "Vilnius",
                Photo =
                    "https://lh3.googleusercontent.com/p/AF1QipMdaJvkiTMywIVIyEXfu3fAn2X2rh81QfIoh_dM=s294-w294-h220-n-k-no"
            },
            new Hotel
            {
                Name = "Palanga Life Balance SPA Hotel",
                Location = "Palanga",
                Photo =
                    "https://lh5.googleusercontent.com/p/AF1QipOQ7XHjuNyN0IN4LIezpO-WHG5TTcuveuW-0Ac5=w592-h404-n-k-no"
            }
        };
        
        context.Hotel.AddRange(hotels);
        context.SaveChanges();
    }
}