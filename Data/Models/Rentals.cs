using System.ComponentModel.DataAnnotations;


namespace CarRental_14665.Data.Models
{
    public class Rentals
    {
        public int Id { get; set; }

        public string? userName { get; set; }

        public string? description { get; set; }

        public int? categoryId { get; set; }

        public Category? Category { get; set;}
    }
}
