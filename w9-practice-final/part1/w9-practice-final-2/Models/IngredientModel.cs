using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace w9_practice_final_1.Models
{
    public class IngredientModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Quantity { get; set; }

    }
}
