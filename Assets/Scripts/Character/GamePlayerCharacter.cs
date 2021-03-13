using UnityEngine;

namespace BeanGame
{
	public class GamePlayerCharacter : GameCharacter
	{
		public enum ActionSkill
		{
			NONE,
			ACTIONSKILL_1,
			ACTIONSKILL_2,
		}
		
		[Header("Player Stats")]
		public int                             characterID;
		public string                          characterName;

		public int                             characterActionSkill;
		public bool                            characterActionSkillActive = false;

		public PlayerInventory                 characterInventory;

		public void EquipWeapon(int slot, Weapon w)
		{
			// TODO:
			// CHECK IF SLOT IS NOT EMPTY
			// IF IT IS NOT
			// SET THIS GAMECHARACTER'S CURRENT WEAPON TO SLOT
			// ELSE
			// RETURN
			
			
		}

	}
}