namespace ConsoleAppBoilerplate
{
	public class FilePathInfo
	{
		#region Properties

		/// <summary>
		/// Gets the base path of application.
		/// </summary>
		public static string BasePath => Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.ToString();

		#endregion
	}
}
