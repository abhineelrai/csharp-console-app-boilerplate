namespace ConsoleAppBoilerplate
{
	public class GuidDataTableService : IDataTableService
	{
		private int[] sharedArray = new int[5];
		public void CompareAndUpdate(int[] guidArr, string placeHolder) // [1,2,3,4,5]
		{
			//Thread.Sleep(1000);
			//sharedArray = new int[guidArr.Length];
			for (int i = 0; i < guidArr.Length; i++)
			{
				sharedArray[i] = placeHolder == "ClassA" ? i * 2 : i * 5;
			}

			// [2,4,6,8,10]

			Thread.Sleep(100);

			foreach (int i in sharedArray)
			{
				Console.Write($"{placeHolder} :{i}\t");
			}
			Console.WriteLine();
		}
	}
}
