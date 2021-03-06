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
		public float                 weaponSpread;
		public float                 weaponRange;
		public List<WeaponPart>      weaponParts;
		public GameItem              weaponBaseItem;
		public Looks                 weaponLooks;
		public float                 cycleTime;
		public int                   bulletCount;
		public bool                  isHitscan;
		public float                 currentCycleTime;
		public GameProjectileEffect  weaponProjectileEffect;
		public FiringMode            weaponFiringMode;
		
		public void Fire(Vector3 startPosition , Vector3 pos, Vector3 dir, Vector3 up, Vector3 right)
		{
			// TODO: OBJECT POOLING SPECIFICALLY FOR PROJECTILES

			//GameObject go = new GameObject("Projectile");
			//var proj = go.AddComponent<GameProjectile>();
			//proj.projectileEffect = weaponProjectileEffect;
			//proj.WakeProjectile();

			currentCycleTime = cycleTime;
			for (int bulletToFire = 0; bulletToFire < bulletCount; bulletToFire++)
			{
				GameObject bullet = new GameObject();
				Bullet b = bullet.AddComponent<Bullet>();
				b.BulletDamage = weaponDamage;
				//b.IsHitscan = isHitscan;
				b.projectile = bullet.AddComponent<GameProjectile>();
				b.projectile.projectileEffect = new GameProjectileEffect();
				b.projectile.projectileEffect.onFireEffect = GameProjectileEffect.OnFired.HITSCAN;
				b.FireBullet(pos, dir, up, right, weaponSpread, weaponRange);
			}

		}
	}
}