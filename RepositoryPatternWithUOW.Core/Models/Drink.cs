using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RepositoryPatternWithUOW.Core.Models
{
    public class Drink
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Drink ID")]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "Varchar(MAX)")]
        [MaxLength(150)]
        [Display(Name = "Drink Name")]
        public string DrinkName { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Produce date")]
        public DateTime ProduceDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Expiration date")]
        public DateTime ExpirationDate { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Column(TypeName = "Varchar(150)")]
        [Display(Name = "Image Name")]
        public string ImageName { get; set; }
        [NotMapped]
        [Display(Name ="Upload Image")]
        public IFormFile ImageFile { get; set; }
    }
}
