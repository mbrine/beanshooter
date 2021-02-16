using UnityEngine;

namespace BeanGame
{
	[RequireComponent(typeof(GameCharacter))]
	public class GamePlayerCharacter : GameCharacter
	{
		[Header("File Stats")]
		public int        characterID;
		public string     characterName;
		
		
	}
}