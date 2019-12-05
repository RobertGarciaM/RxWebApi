using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataApi.Models
{
    [Table("ProductsModel", Schema = "dbo")]
    public class ProductsModel
    {
        [Key]
        public int idProduct { get; set; }

        [Required]
        [MaxLength(100)]
        public string nameProduct { get; set; }
        [Required]
        public int quantityAvaible { get; set; }
    }
}
