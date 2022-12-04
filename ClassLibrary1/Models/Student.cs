using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantini.Database.Model
{
    public class Student
    {
        [Key]
        public int SId { get; set; }
        [Required]
        public string SName { get; set; }

        public string SEmail { get; set; }

        public string Faculty { get; set; }
    }
}
