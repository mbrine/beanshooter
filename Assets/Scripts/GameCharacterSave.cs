using System;
using UnityEngine;

namespace BeanGame
{
	[Serializable]
	public class GameCharacterSave
	{
		[SerializeField] public int                          CharacterID;
		[SerializeField] public string                       CharacterName;
		[SerializeField] public int                          CharacterActionSkill;
		[SerializeField] public PlayerInventory              CharacterInventory;

		[SerializeField] public float                        BaseHealth;
	}
}