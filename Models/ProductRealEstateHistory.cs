using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Models
{
    public class ProductRealEstateHistory
    {
        [Key]
        public int Id { get; set; }
        public int ProductRealEstateId { get; set; }
        public string productLocation { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public int TotalNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
