using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
       
        public string? FullName { get; set; }

        public string District { get; set; } = null!;

        public string Code { get; set; } = null!;

        public bool IsActive { get; set; } = false;

        public DateTime CreatedAt { get; set; }
    }
}
