using System;
using System.Collections.Generic;
using System.Linq;

namespace ShiftsLoggerApp.Models
{

    public class ShiftModel
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DateTime UpdatedAt { get; set; }

    }


}