namespace ConsoleAppBoilerplate
{
	public class ClassB : BaseClass
	{
		private readonly IDataTableService dataTableService;
		public ClassB(DataTableServiceResolver resolver) : base(resolver)
		{
			dataTableService = resolver.Resolve<ClassB>();
		}

		public override void Migrate()
		{
			dataTableService.CompareAndUpdate(new int[] { 1, 2, 3, 4, 5 }, "ClassB");
		}
	}
}
