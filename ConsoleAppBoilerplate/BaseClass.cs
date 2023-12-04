namespace ConsoleAppBoilerplate
{
	public class BaseClass
	{
		public readonly DataTableServiceResolver dataTableServiceResolver;

		public BaseClass(DataTableServiceResolver dataTableServiceResolver)
		{
			this.dataTableServiceResolver = dataTableServiceResolver;
		}
		public virtual void Migrate()
		{
			Console.WriteLine("Inside Base Class");
		}

		public void Run()
		{
			// set 1 do here
			var tasks = new List<Task>()
			{
				Task.Run(() => CreateAndMigrate<ClassA>()),
				//Task.Run(() => CreateAndMigrate<ClassB>()),
				Task.Run(() => CreateAndMigrate<ClassC>()),
			};

			Task.WaitAll(tasks.ToArray());

			// set 2 do here

			// set 3 do here
		}

		private void CreateAndMigrate<T>() where T : BaseClass
		{
			var instance = (T)Activator.CreateInstance(typeof(T), new object[] { dataTableServiceResolver });
			instance.Migrate();
		}
	}
}
