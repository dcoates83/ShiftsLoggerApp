using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ShiftsLoggerApp.Models
{
    public class ShiftModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime? Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
