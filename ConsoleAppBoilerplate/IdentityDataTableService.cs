namespace ConsoleAppBoilerplate
{
	public class IdentityDataTableService : IDataTableService
	{
		public void CompareAndUpdate(int[] identityArr, string placeHolder)
		{
			//Thread.Sleep(1000);
			for (int i = 0; i < identityArr.Length; i++)
			{
				identityArr[i] = i * 3;
			}

			foreach (int i in identityArr)
			{
				Console.Write($"{placeHolder} :{i}\t");
			}
			Console.WriteLine();
		}
	}
}
