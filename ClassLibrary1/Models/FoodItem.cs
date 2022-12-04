using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantini.Database.Model
{
    public class FoodItem
    {
        [Key]
        public int FId { get; set; }
        [Required]
        public string FName { get; set; }

        public int FPrice { get; set; }

    }
}