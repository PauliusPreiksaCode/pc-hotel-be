using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotelAPI.Entities;

public class Hotel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    public required string Name { get; set; }
    
    public required string Location { get; set; }

    public required string Photo { get; set; } 
}