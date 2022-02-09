using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.Models
{
    public class Coins
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Sale ID")]
        public int Id { get; set; }
        [Required]
        public int Coin { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public bool IsFull { get; set; }

    }
}
