using System;
using UnityEngine;

namespace BeanGame
{
	[Serializable]
	public class GameCharacterSave
	{
		[SerializeField] public int        CharacterID;
		[SerializeField] public string     CharacterName;
		
		[SerializeField] public float      BaseHealth;
	}
}