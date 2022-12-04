using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantini.Database.Model
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("FoodItem")]
        public int FId { get; set; }
        public int Quantity { get; set; }
        [Range(1,5, ErrorMessage = "Display Order must be between 1 and 5 only!!")]
        public int Rate { get; set; }

        [ForeignKey("Order")]
        public int OId { get; set; }

        public virtual FoodItem FoodItem { get; set; }
        public virtual Order Order { get; set; }

    }

}