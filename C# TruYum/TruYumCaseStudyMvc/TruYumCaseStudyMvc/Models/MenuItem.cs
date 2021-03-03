using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruYumCaseStudyMvc.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        public bool Active { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
ApplyFormatInEditMode = true)]
        [Display(Name ="Date Of Launch")]
        public DateTime Dof { get; set; }


        [Display(Name ="Free Delivery")]
        public bool free { get; set; }

      
        [Display(Name="Category")]
        public int CategoryId { get; set; }
        
        [ForeignKey("CategoryId")]
        public Category GetCategory { get; set; }


    }
}