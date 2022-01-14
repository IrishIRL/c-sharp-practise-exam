using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ExamWebApp.Domain
{
    //[Index(new[] {nameof(IngredientId)}, IsUnique = true)]
    public class User:BaseEntity
    {
        [MaxLength(64)] public string Username { get; set; } = default!;
        public ICollection<UsersIngredients>? UsersIngredients { get; set; }
    }
}