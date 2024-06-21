using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ShiftsLoggerApp.Models;
using ShiftsLoggerApp.Services;

namespace ShiftsLoggerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService _service;

        public ShiftController(IShiftService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetShifts()
        {
            var shifts = await _service.GetShifts();
            return Ok(shifts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShiftById(int id)
        {
            var shift = await _service.GetShiftById(id);
            if (shift == null)
            {
                return NotFound();
            }
            return Ok(shift);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShift([FromBody] ShiftModel shift)
        {
            List<string> errors = new List<string>();
            if (!ModelState.IsValid)
            {
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                return BadRequest(errors);
            }
            var newShift = await _service.CreateShift(shift);
            return CreatedAtAction(nameof(GetShiftById), new { id = newShift.Id }, newShift);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShift(int id, [FromBody] ShiftModel shift)
        {
            try
            {
                var updatedShift = await _service.UpdateShift(id, shift);
                return Ok(updatedShift);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShift(int id)
        {
            try
            {
                var deletedShift = await _service.DeleteShift(id);
                return Ok(deletedShift);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
