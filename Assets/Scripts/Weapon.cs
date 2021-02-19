using System.Collections.Generic;
using UnityEngine;

namespace BeanGame
{
	[CreateAssetMenu(fileName = "Game Weapon", menuName = "BeanGame/New Game Weapon")]
	public class Weapon : ScriptableObject
	{
		public string            WeaponName;
		public Damage            WeaponDamage;
		public List<WeaponPart>  WeaponParts;
		
		void Fire()
		{
			
		}

	}
}