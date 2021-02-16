using System;
using System.IO;
using BeanGame;
using UnityEditor;
using UnityEngine;

public class SaveTester : EditorWindow
{
	string characterName;

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
			c.baseHealth = 100;
			GameSaveLoadHandler.SaveToon(c);
			DestroyImmediate(go);
		}

		if (GUILayout.Button("Load A Char"))
		{
			GameObject go = new GameObject("dummy");
			GamePlayerCharacter pc = go.LoadToon(Path.Combine(GameStrings.SavesLocation, "SAVE_1.bgsave"));
			go.name = pc.characterName;
		}
	}
}