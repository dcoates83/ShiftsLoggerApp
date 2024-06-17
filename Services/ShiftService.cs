using System;
using System.Collections.Generic;
using System.Linq;
using ShiftsLoggerApp.Data;
using ShiftsLoggerApp.Models;

namespace ShiftsLoggerApp.Services
{
    public interface IShiftService
    {
        List<ShiftModel> GetShifts();
    }

    public class ShiftService : IShiftService
    {
        private readonly ApplicationDbContext _context;

        public ShiftService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ShiftModel> GetShifts()
        {
            return _context.Shifts.ToList();
        }
    }
}
