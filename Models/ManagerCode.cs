using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Models
{
    public class ManagerCode
    {
        [Key]
        public int Id { get; set; }
        public string TypeManager { get; set; }=string.Empty;

        public string GeneratedBy { get; set; } = "Admin";

        public bool Used { get; set; } = false;

        public string Code { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
