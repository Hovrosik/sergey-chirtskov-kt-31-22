using ChirtskovSergeyKt_31_22.Database;
using ChirtskovSergeyKt_31_22.Interfaces.TeacherInterfaces;
using ChirtskovSergeyKt_31_22.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChirtskovSergeyKt_31_22.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<TeacherController> _logger;
        private readonly IDepartmentService _departmentService;
        private readonly TeacherDbContext _context;

        public DepartmentController(ILogger<TeacherController> logger, IDepartmentService departmentService, TeacherDbContext context)
        {
            _logger = logger;
            _departmentService = departmentService;
            _context = context;
        }



        [HttpPost("create")]
        public async Task<IActionResult> CreateDepartmentByUrlAsync([FromQuery] string? departmentName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(departmentName))
                return BadRequest("Название кафедры не может быть пустым.");

            var newDepartment = new Department
            {
                DepartmentName = departmentName,
                isDeleted = false
            };

            var created = await _departmentService.CreateAsync(newDepartment, cancellationToken);

            return Ok(created);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateDepartmentNameAsync([FromQuery] int id, [FromQuery] string newName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(newName))
                return BadRequest("Новое имя кафедры не может быть пустым.");

            var result = await _departmentService.UpdateDepartmentNameAsync(id, newName, cancellationToken);

            if (result == null)
                return NotFound($"Кафедра с ID = {id} не найдена или была удалена.");

            return Ok(result);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteDepartmentAsync([FromQuery] int id, CancellationToken cancellationToken = default)
        {
            var result = await _departmentService.DeleteDepartmentAsync(id, cancellationToken);

            if (!result)
                return NotFound($"Кафедра с ID = {id} не найдена или уже удалена.");

            return Ok($"Кафедра с ID = {id} успешно удалена.");
        }


    }
}
