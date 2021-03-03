using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruYumCaseStudyMvc.Models
{
    public class Cart
    {     
        [Key]
        public int Id { get; set; }

        
        [Display(Name ="MenuItem")]
        public int MenuItemId { get; set; }

        
        [ForeignKey("MenuItemId")]        
        public MenuItem GetMenuItem{ get; set; }
    }
}