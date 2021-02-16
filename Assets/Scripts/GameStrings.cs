using System;
using System.IO;

namespace BeanGame
{
	public class GameStrings
	{
		public static string GameName => "BeanGame";
		private static string MyGamesFolder => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "My Games");
		public static string SavesLocation => Path.Combine(MyGamesFolder, GameName, "Saves");
	}
}