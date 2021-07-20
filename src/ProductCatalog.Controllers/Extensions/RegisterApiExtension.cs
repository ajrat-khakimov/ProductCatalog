namespace Abdt.ConsumerLoan.Adapter.SiebelCrm.Controllers
{
    using System.Reflection;
	using Ardalis.GuardClauses;
	using Microsoft.Extensions.DependencyInjection;

    internal static class RegisterApiExtension
    {
		public static IMvcBuilder RegisterApi(this IMvcBuilder builder)
		{
			Guard.Against.Null(builder, nameof(builder));

			return builder
				.AddApplicationPart(Assembly.GetAssembly(typeof(RegisterApiExtension)))
				.AddControllersAsServices();
		}
	}
}