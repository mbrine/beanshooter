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
			CHARGE, // projectile is fired when trigger up
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
		public Looks                 weaponLooks;
		
		// NOTE THAT 0 MEANS THAT THE GUN WILL FIRE AS FAST AS THE PLAYER CAN PULL THE TRIGGER (BL2 JAKOBS PISTOL)
		public float                 weaponFireRate; 
		
		public float                 weaponFireRateTimer; // DITTO
		public int                   weaponPelletCount = 1; // SHOULD DEFAULT TO 1
		// your (mbrine's) stuff
		public float                 cycleTime;
		public int                   bulletCount;
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
		// end 
		public GameProjectileEffect  weaponProjectileEffect;
		public FiringMode            weaponFiringMode;
		public bool                  weaponTriggerDown; // MUST BE SET BY THE CONTROLS
		public bool                  weaponIsFreeToFire;
		
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

        /// <summary>
        ///   <para>Meant to simulate a weapon's trigger.</para>
        /// </summary>
        /// <remarks>true - Weapon's trigger is pressed/held down.
        /// false - Weapon's trigger is released.</remarks>
        public void ToggleWeaponTrigger(bool triggerState)
        {
	        weaponTriggerDown = triggerState;
	        switch (weaponFiringMode)
	        {
		        case FiringMode.SEMI:
		        {
			        if (triggerState)
			        {
				        if (weaponIsFreeToFire)
				        {
					        // FIRE PROJECTILES
					        // TODO: CALL FIRE METHOD HERE
					        weaponIsFreeToFire = false;
				        }
			        }
			        break;
		        }
		        case FiringMode.CHARGE:
		        {
			        if (triggerState)
			        {
				        
			        }
			        else
			        {
				        // this is where a charge shot projectile should Fire
			        }
			        break;
		        }
		        case FiringMode.AUTO:
		        {
			        if (triggerState)
			        {
				        
			        }
			        break;
		        }
				
				
	        }
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
				b.projectile.projectileEffect = weaponProjectileEffect;
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