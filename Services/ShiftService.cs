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
        ValueTask<ShiftModel?> GetShiftById(int id);
        Task<ShiftModel> CreateShift(ShiftModel shift);
        Task<ShiftModel> UpdateShift(int id, ShiftModel shift);
        Task<ShiftModel> DeleteShift(int id);
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

        public ValueTask<ShiftModel?> GetShiftById(int id)
        {
            return _context.Shifts.FindAsync(id);
        }

        public async Task<ShiftModel> CreateShift(ShiftModel shift)
        {
            _context.Shifts.Add(shift);
            await _context.SaveChangesAsync();
            return shift;
        }

        public async Task<ShiftModel> UpdateShift(int id, ShiftModel shift)
        {
            var existingShift = await _context.Shifts.FindAsync(id);
            if (existingShift == null)
            {
                throw new Exception("Shift not found");
            }
            existingShift.Date = shift.Date;
            existingShift.StartTime = shift.StartTime;
            existingShift.EndTime = shift.EndTime;
            existingShift.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return shift;
        }

        public async Task<ShiftModel> DeleteShift(int id)
        {
            var shift = await _context.Shifts.FindAsync(id);
            if (shift == null)
            {
                throw new Exception("Shift not found");
            }

            _context.Shifts.Remove(shift);
            await _context.SaveChangesAsync();
            return shift;
        }
    }
}
