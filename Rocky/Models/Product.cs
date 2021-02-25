using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1,int.MaxValue)]
        public string Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        [Display(Name = "Category Type")]
        public int CategoryId { get; set; }          //foreign key
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }       //linking category and product table with foreign ke

        [Display(Name = "Application Type")]
        public int ApplicationTypeId { get; set; }          //foreign key
        [ForeignKey("ApplicationTypeId")]
        public virtual Application_Model ApplicationType { get; set; }
    }
}
