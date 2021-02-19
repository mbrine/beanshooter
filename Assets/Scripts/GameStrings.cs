using System;
using System.Collections.Generic;
using System.IO;

namespace BeanGame
{
	public class GameStrings
	{	
		public static string    GameName => UnityEngine.Application.productName; // NOW USES PRODUCT NAME, PLEASE CHANGE THERE
		private static string   MyGamesFolder => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "My Games");
		public static string    SavesLocation => Path.Combine(MyGamesFolder, GameName, "Saves");

		public static Dictionary<string, string> someDictionary = new Dictionary<string, string>()
		{
			{"abc", "def"}
		};

	}
}