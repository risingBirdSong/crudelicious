using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]

        public int DishId { get; set; }

        [Required]
        [Display(Name="Name of Recipe")]
        public string Name { get; set; }
        [Display(Name = "Name of Chef")]
        [Required]

        public string Chef { get; set; }
        [Required]

        [Display(Description = "How Tasty")]
        public int Tastiness { get; set; }

        [Required]

        [Display(Description = "The amount of Calories")]
        public int Calories { get; set; }
        [Display(Description = "A Description of the recipe")]
        [Required]

        public string Description { get; set; }
    
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Dish() { }

    }
}
