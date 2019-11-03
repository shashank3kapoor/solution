using System;
namespace CoreApi.Repositories {
	public class BaseRepository {
		public string docPath;
		public string fileName;

		public BaseRepository ()
		{
			docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		}
	}
}
