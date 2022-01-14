using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamWebApp.Domain
{
    public class Measurement:BaseEntity
    {
        [MaxLength(64)]
        public string MeasurementName { get; set; } = default!;
        
        public ICollection<RecipeIngredient>? RecipeIngredient { get; set; }
        public ICollection<UsersIngredients>? UsersIngredients { get; set; }
    }
}