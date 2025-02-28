using ChirtskovSergeyKt_31_22.Interfaces.TeacherInterfaces;

namespace ChirtskovSergeyKt_31_22.ServiceExtensions
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<ITeacherService, TeacherService>();

			return services;
		}
	}
}
