using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Models
{
    public class ProductTexnologyHistory
    {
        [Key]
        public int Id { get; set; }
        public int ProductTexnologyId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int TotalNumber { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
