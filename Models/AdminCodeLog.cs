using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Models
{
    public class AdminCodeLog
    {
        [Key]
        public int Id { get; set; }

        public string GeneratedCode { get; set; } = string.Empty;

        public string District { get; set; } = string.Empty;

        public string GeneratedBy { get; set; } = "superadmin";

        public bool Used { get; set; } = false;

        public DateTime? UsedAt { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
