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
        public List<ShiftModel> GetShifts()
        {
            return _service.GetShifts();
        }
    }
}
