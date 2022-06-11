using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collection_Management_API.Data;
using Collection_Management_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Collection_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly TestDbContext _context;

        public TestController(TestDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Test>> Get()
        {
            return await _context.Tests.ToListAsync();
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var test = await _context.Tests.FindAsync(id);
            return test == null ? NotFound() : Ok(test);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Test test)
        {
            await _context.Tests.AddAsync(test);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = test.Id }, test);
        }
    }
}