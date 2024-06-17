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
    }
}
