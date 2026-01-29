using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Models
{
    public class Manager
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }=string.Empty;
        public string ManagerCode { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        public DateTime CreatedAt { get; set; }
    }
}
