using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Models
{
    public class ProductRealEstate
    {
        [Key]
        public int Id { get; set; }
        public string ProductType { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public int CategoryId { get; set; }
        public int ManagerId { get; set; }
        public string productLocation { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public int TotalNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
