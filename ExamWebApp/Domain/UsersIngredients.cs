using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ExamWebApp.Domain
{
    [Index(new[] {nameof(UserId), nameof(IngredientId)}, IsUnique = true)]
    public class UsersIngredients:BaseEntity
    {
        public int UserId { get; set; }
        public User? User { get; set; }
        
        public int IngredientId { get; set; }
        public Ingredient? Ingredient { get; set; }
        public float Quantity { get; set; }
        public int MeasurementId { get; set; }
        public Measurement? Measurement { get; set; }
    }
}