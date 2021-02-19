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
		public int                          characterID;
		public string                       characterName;

		public int                          characterActionSkill;
		public bool                         characterActionSkillActive = false;

		public GamePlayerCharacterInventory characterInventory;



	}
}