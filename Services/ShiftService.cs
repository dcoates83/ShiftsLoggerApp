using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShiftsLoggerApp.Data;
using ShiftsLoggerApp.Models;

namespace ShiftsLoggerApp.Services
{
    public interface IShiftService
    {
        Task<List<ShiftModel>> GetShifts();
    }

    public class ShiftService : IShiftService
    {
        private readonly ApplicationDbContext _context;

        public ShiftService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<ShiftModel>> GetShifts()
        {
            return _context.Shifts.ToListAsync();
        }
    }
}
