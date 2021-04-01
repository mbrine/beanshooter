using UnityEngine;
using UnityEditor;
using BeanGame;


[CustomEditor(typeof(Weapon))]
public class WeaponEditor : Editor
{
	private static Texture2D TextureField(string name, Texture2D texture)
	{
		GUILayout.BeginVertical();
		var style = new GUIStyle(GUI.skin.label);
		style.alignment = TextAnchor.UpperCenter;
		style.fixedWidth = 70;
		GUILayout.Label(name, style);
		var result = (Texture2D)EditorGUILayout.ObjectField(texture, typeof(Texture2D), false, GUILayout.Width(70), GUILayout.Height(70));
		GUILayout.EndVertical();
		return result;
	}

	private static Sprite SpriteField(string name, Sprite sprite)
	{
		GUILayout.BeginVertical();
		var style = new GUIStyle(GUI.skin.label);
		style.alignment = TextAnchor.UpperCenter;
		style.fixedWidth = 70;
		GUILayout.Label(name, style);
		var result = (Sprite)EditorGUILayout.ObjectField(sprite, typeof(Sprite), false, GUILayout.Width(70), GUILayout.Height(70));
		GUILayout.EndVertical();
		return result;
	}

	public override void OnInspectorGUI()
	{
		GUIStyle header_style = new GUIStyle(GUI.skin.label);
		header_style.fontSize = 32;
		Weapon w = (Weapon) target;
		
		GUILayout.Label("Item Properties", header_style);		
		GUILayout.BeginHorizontal();
		w.itemSprite = (Sprite)SpriteField("Item Sprite", w.itemSprite);
		GUILayout.BeginVertical();
		GUILayout.Label("Item Name");
		w.itemName = EditorGUILayout.TextField(w.itemName);
		GUILayout.Label("Item Rarity");
		w.itemRarity = (GameItem.Rarity.Level)EditorGUILayout.EnumPopup(w.itemRarity);
		GUILayout.EndVertical();
		GUILayout.EndHorizontal();

		#region DEFAULT EDITOR
		EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.Label("DEFAULT   EDITOR", header_style); 
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
		base.OnInspectorGUI();
		#endregion
	}
}
