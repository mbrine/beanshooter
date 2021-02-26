using System.Collections.Generic;
using UnityEngine;

namespace BeanGame
{
	[CreateAssetMenu(fileName = "New Game Weapon", menuName = "BeanGame/Weapon", order = 0)]
	public class Weapon : GameItem
	{
		public Damage            weaponDamage;
		public List<WeaponPart>  weaponParts;

		public GameItem          weaponBaseItem;

		public Looks             weaponLooks;
		
		void Fire()
		{
			
		}

	}
}