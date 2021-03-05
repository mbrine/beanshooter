using System.Collections.Generic;
using UnityEngine;

namespace BeanGame
{
	[CreateAssetMenu(fileName = "New Game Weapon", menuName = "BeanGame/Weapon", order = 0)]
	public class Weapon : GameItem
	{
		public enum FiringMode
		{
			SEMI,
			AUTO,
			BURST_2,
			BURST_3,
			BURST_5,
		}
	
		public Damage                weaponDamage;
		public List<WeaponPart>      weaponParts;
		public GameItem              weaponBaseItem;
		public Looks                 weaponLooks;
		public GameProjectileEffect  weaponProjectileEffect;
		public FiringMode            weaponFiringMode;
		
		void Fire(Vector3 startPosition /*SHOULD BE A POINT ON A WEAPON*/, Vector3 direction)
		{
			// TODO: OBJECT POOLING SPECIFICALLY FOR PROJECTILES

			GameObject go = new GameObject("Projectile");
			var proj = go.AddComponent<GameProjectile>();
			proj.projectileEffect = weaponProjectileEffect;
			proj.WakeProjectile();
			
		}
	}
}