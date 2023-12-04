using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAppBoilerplate
{
	public class DataTableServiceResolver
	{
		private readonly IServiceProvider serviceProvider;

		public DataTableServiceResolver(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}

		public IDataTableService Resolve<T>()
		{
			if (typeof(T) == typeof(ClassA) || typeof(T) == typeof(ClassC))
			{
				return serviceProvider.GetRequiredService<GuidDataTableService>();
			}
			else if (typeof(T) == typeof(ClassB))
			{
				return serviceProvider.GetRequiredService<IdentityDataTableService>();
			}
			throw new InvalidOperationException("Unsupported class type");
		}
	}
}
