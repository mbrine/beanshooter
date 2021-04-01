using System;
using System.Collections.Generic;
using System.IO;
using BeanGame;
using UnityEditor;
using UnityEngine;

public class SaveTester : EditorWindow
{
	string _characterName = "";
	private List<string> _listNames = new List<string>();

	[MenuItem("Window/My Game/ShowWindow")]
	public static void Init()
	{
		GetWindow<SaveTester>().Show();
	}
	
	private void OnGUI()
	{
		_characterName = GUILayout.TextField(_characterName);
		if (GUILayout.Button("Save This Char"))
		{
			GameObject go = new GameObject("dummy");
			GamePlayerCharacter c = go.AddComponent<GamePlayerCharacter>();
			c.characterID = 1;
			c.characterName = _characterName;
			c.BaseHealth = 100;
			GameSaveLoadHandler.SavePlayerCharacter(c);
			DestroyImmediate(go);
		}

		if (GUILayout.Button("Load A Char"))
		{
			GameObject go = new GameObject("dummy");
			GamePlayerCharacter pc = go.LoadPlayerCharacter(Path.Combine(GameStrings.SavesLocation, "SAVE_1.bgsave"));
			go.name = pc.characterName;
		}

		if (GUILayout.Button("Get Char Names"))
		{
			_listNames = GameSaveLoadHandler.GetListOfCharacters();
		}

		if (_listNames.Count > 0)
		{
			foreach (string a in _listNames)
			{
				GUILayout.Label(a);	
			}
		}
	}
}