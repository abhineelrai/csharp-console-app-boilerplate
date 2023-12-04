namespace ConsoleAppBoilerplate
{
	public class ClassA : BaseClass
	{
		private readonly IDataTableService dataTableService;
		public ClassA(DataTableServiceResolver resolver) : base(resolver)
		{
			dataTableService = resolver.Resolve<ClassA>();
		}

		public override void Migrate()
		{
			dataTableService.CompareAndUpdate(new int[] { 1, 2, 3, 4, 5 }, "ClassA");
		}
	}
}
