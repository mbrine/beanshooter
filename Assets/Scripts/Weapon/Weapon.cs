using System.Collections.Generic;
using UnityEngine;

namespace BeanGame
{
	[CreateAssetMenu(fileName = "New Game Weapon", menuName = "BeanGame/Weapon", order = 0)]
	public class Weapon : GameItem
	{
		public Damage            weaponDamage;
		public float             weaponSpread;
		public float             weaponRange;
		public float             cycleTime;
		public int               bulletCount;
        public bool              isHitscan;
		public List<WeaponPart>  weaponParts;
		public float             currentCycleTime;

		public GameItem          weaponBaseItem;

		public Looks             weaponLooks;

        public void Fire(Vector3 pos, Vector3 dir,Vector3 up,Vector3 right)
        {
            currentCycleTime = cycleTime;
            for (int bulletToFire = 0; bulletToFire < bulletCount; bulletToFire++)
            {
                GameObject bullet = new GameObject();
                Bullet b = bullet.AddComponent<Bullet>();
                b.BulletDamage = weaponDamage;
                //b.IsHitscan = isHitscan;
                b.projectile = bullet.AddComponent<GameProjectile>();
                b.projectile.projectileEffect = new GameProjectileEffect();
                b.projectile.projectileEffect.onFireEffect=GameProjectileEffect.OnFired.HITSCAN;
                b.FireBullet(pos, dir,up,right, weaponSpread, weaponRange);
            }
        }

	}
}