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

        //Up to original mag size of recoil patterns
        public List<Vector2> recoilPattern;


        public Damage                weaponDamage;
		public float                 weaponSpread;
		public float                 weaponRange;
		public List<WeaponPart>      weaponParts;
		public GameItem              weaponBaseItem;
		public Looks                 weaponLooks;
		public GameProjectileEffect  weaponProjectileEffect;
		public FiringMode            weaponFiringMode;

		public float                 cycleTime;
		public int                   bulletCount;
		public bool                  isHitscan;
        public int                   magazineSize;
        public int                   recoilLoopPoint;
        public float                 recoilPerShot;
        public float                 recoilRecovery;

        public float                 recoilAmount;
        public float                 recoilCurrent;
        public int                   recoilIndex = 0;
        public float                 currentRecoil = 0.0f;
        public int                   remainingBullets;
		public float                 currentCycleTime;
		
        public void Init()
        {
            Random.InitState(magazineSize * bulletCount + (int)weaponFiringMode);
            currentRecoil = 0;
            recoilIndex = 0;
            currentCycleTime = 0;
            recoilAmount = 0;
        }

        public void Update()
        {
            currentCycleTime -= Time.deltaTime;
            recoilAmount = Mathf.MoveTowards(recoilCurrent, 0.0f, recoilCurrent*recoilRecovery * Time.deltaTime);
            if (recoilAmount <= 0.0f)
                recoilIndex = 0;
        }

		public void Fire(Vector3 startPosition , Vector3 pos, Vector3 dir, Vector3 up, Vector3 right)
		{
            // TODO: OBJECT POOLING SPECIFICALLY FOR PROJECTILES

            //GameObject go = new GameObject("Projectile");
            //var proj = go.AddComponent<GameProjectile>();
            //proj.projectileEffect = weaponProjectileEffect;
            //proj.WakeProjectile();

            if (recoilIndex >= recoilPattern.Count)
            {
                recoilIndex = recoilLoopPoint;
                //recoilIndex = ((recoilIndex - recoilLoopPoint) % recoilPattern.Count) + recoilLoopPoint;
            }
            Debug.Log("Recoil:" + recoilIndex);
            Vector2 recoilPos = recoilPattern[recoilIndex] * recoilAmount;

			for (int bulletToFire = 0; bulletToFire < bulletCount; bulletToFire++)
			{
				GameObject bullet = new GameObject();
				Bullet b = bullet.AddComponent<Bullet>();
				b.BulletDamage = weaponDamage;
				b.projectile = bullet.AddComponent<GameProjectile>();
				b.projectile.projectileEffect = new GameProjectileEffect();
				b.projectile.projectileEffect.onFireEffect = GameProjectileEffect.OnFired.HITSCAN;
				b.FireBullet(pos, dir, up, right, recoilPos, weaponSpread, weaponRange);
			}
			currentCycleTime = cycleTime;
            recoilAmount += recoilPerShot;
            recoilCurrent = recoilAmount;
            ++recoilIndex;
		}
	}
}