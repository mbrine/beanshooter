using System;
using System.Collections.Generic;
using System.IO;
using BeanGame;
using UnityEditor;
using UnityEngine;

public class SaveTester : EditorWindow
{
	string characterName;
	private List<string> listNames = new List<string>();

	[MenuItem("Window/My Game/ShowWindow")]
	public static void Init()
	{
		GetWindow<SaveTester>().Show();
	}
	
	private void OnGUI()
	{
		characterName = GUILayout.TextField(characterName);
		if (GUILayout.Button("Save This Char"))
		{
			GameObject go = new GameObject("dummy");
			GamePlayerCharacter c = go.AddComponent<GamePlayerCharacter>();
			c.characterID = 1;
			c.characterName = characterName;
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
			listNames = GameSaveLoadHandler.GetListOfCharacters();
		}

		if (listNames.Count > 0)
		{
			foreach (string a in listNames)
			{
				GUILayout.Label(a);	
			}
		}
	}
}