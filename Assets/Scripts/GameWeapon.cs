using UnityEngine;

namespace BeanGame
{
	[CreateAssetMenu(fileName = "Game Weapon", menuName = "BeanGame/New Game Weapon")]
	public class GameWeapon : ScriptableObject
	{
		public string WeaponName;
		public float WeaponValue;
	}
}