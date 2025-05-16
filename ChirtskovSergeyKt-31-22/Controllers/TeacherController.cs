using ChirtskovSergeyKt_31_22.Filters.TeacherFilters;
using ChirtskovSergeyKt_31_22.Interfaces.TeacherInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChirtskovSergeyKt_31_22.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TeacherController : ControllerBase
	{
		private readonly ILogger<TeacherController> _logger;
		private readonly ITeacherService _teacherService;

		public TeacherController(ILogger<TeacherController> logger, ITeacherService teacherService)
		{
			_logger = logger;
			_teacherService = teacherService;
		}

		[HttpGet(Name = "GetTeacher")]
		public async Task<IActionResult> GetTeachersAsync([FromQuery] TeacherFilter filter, CancellationToken cancellationToken = default)
		{
			var teacher = await _teacherService.GetTeachersAsync(filter, cancellationToken);

			if (teacher == null || teacher.Length == 0)
			{
				return NotFound("Преподавателей с указанным фильтром нет в базе");
			}

			return Ok(teacher);		

		}





	}
}
