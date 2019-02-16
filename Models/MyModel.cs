using System;
using System.ComponentModel.DataAnnotations;

namespace crudelicious.Models
{
    public class MyModel
    {
        [Key]
        public int MyModelId {get; set;}

       [Required]
       [Display(Name = "Chef's Name: ")]
       public string chefName {get; set;}

        [Required]
        [Display(Name = "Name of Dish: ")]
        public string dishName {get; set;}

        [Required]
        [Display(Name = "# of Calories:")]
        public int Calories {get; set;}

        [Required]
        [Display(Name = "Tastiness:")]
        public int Tastiness {get; set;}

        [Required]
        [Display(Name = "Description:")]
        public string Description {get; set;}

        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get;set;}
    }
}