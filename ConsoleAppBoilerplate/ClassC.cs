namespace ConsoleAppBoilerplate
{
	public class ClassC : BaseClass
	{
		private readonly IDataTableService dataTableService;
		public ClassC(DataTableServiceResolver resolver) : base(resolver)
		{
			dataTableService = resolver.Resolve<ClassA>();
		}

		public override void Migrate()
		{
			dataTableService.CompareAndUpdate(new int[] { 5, 6, 7, 8, 9 }, "ClassC");
		}
	}
}
