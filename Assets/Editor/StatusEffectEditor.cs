using BeanGame;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StatusEffect))]
public class StatusEffectEditor : Editor
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
	
	public override void OnInspectorGUI()
	{
		EditorGUI.BeginChangeCheck();
		//base.OnInspectorGUI();
		StatusEffect current = (StatusEffect) target;

		GUILayout.BeginHorizontal();
		current.effectIcon = TextureField("Icon", current.effectIcon);
		GUILayout.BeginVertical();
		GUILayout.Label("Effect Title");
		current.effectTitle = EditorGUILayout.TextField(
			current.effectTitle == string.Empty 
				? "Effect Title Here..." 
				: current.effectTitle
				);
		GUILayout.Label("Effect Desc");
		current.effectDesc = EditorGUILayout.TextField(
				current.effectDesc == string.Empty 
					? "Effect Description Here..." 
					: current.effectDesc
					);
		GUILayout.EndVertical();
		GUILayout.EndHorizontal();
		GUILayout.FlexibleSpace();
		current.effectMaxStacks = EditorGUILayout.IntField("Maximum Stacks", current.effectMaxStacks);
		current.effectDuration = EditorGUILayout.FloatField("Effect Duration", current.effectDuration);
        GUILayout.FlexibleSpace();
		current.isDebuff = GUILayout.Toggle(current.isDebuff, "Effect Is a Debuff");
		current.timerResetsWhenReapplied = GUILayout.Toggle(current.timerResetsWhenReapplied, "Timer Resets When Reapplied");
		
		
		if (EditorGUI.EndChangeCheck())
		{
			EditorUtility.SetDirty(target);
		}
	}
}