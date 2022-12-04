using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantini.Database.Model
{
    public class Order
    {
        
        [Key]
        [DisplayName("Order Id")]
        public int OId { get; set; }
        [DisplayName("Student Id")]
        [ForeignKey("Student")]

        public int SId { get; set; }
        [DisplayName("Ordered Time")]
        public DateTime OrderTime { get; set; }=DateTime.Now;

        
        public virtual Student Student { get; set; }

        public virtual List<OrderDetail> OrderDetail { get; set; }

        //[NotMapped]
        //public List<SelectList> StudentList { get; set; }


    }
}