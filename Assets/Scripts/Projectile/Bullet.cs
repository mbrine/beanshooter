using System.Collections.Generic;
using UnityEngine;

namespace BeanGame
{
    public class Bullet : MonoBehaviour
    {
        public Damage BulletDamage;
        public GameProjectile projectile;

        private static GameObject bulletHoleRef;
        private float lifeTime = 1.0f;
        private bool IsHitscan = false;

        public void FireBullet(Vector3 pos, Vector3 dir, Vector3 up, Vector3 right, float spread, float range, float spreadAngle = 360.0f, float spreadAngleStart = 0.0f)
        {
            if (!bulletHoleRef)
                bulletHoleRef = Resources.Load<GameObject>("BulletHolePrefab");
            //Spread
            Polar spreadP = new Polar(Random.Range(0.0f, spread), Random.Range(0.0f, 360.0f));
            Vector2 spreadV = Polar.PolarToVector2(spreadP);
            Vector3 finalDir = (dir + right * spreadV.x + up * spreadV.y).normalized;

            //Decide if using Hitscan
            switch (projectile.projectileEffect.onFireEffect)
            {
                case GameProjectileEffect.OnFired.HITSCAN:
                    IsHitscan = true;
                    break;
                default:
                    IsHitscan = false;
                    break;
            }

            //Bullet Firing Logic
            if (IsHitscan)
            {
                LineRenderer LR = gameObject.AddComponent<LineRenderer>();
                LR.startWidth = LR.endWidth = 0.01f;
                RaycastHit hit = new RaycastHit();

                Debug.DrawLine(pos, pos + finalDir * range, Color.black);
                if (Physics.Raycast(pos, finalDir, out hit, range))
                {
                    LR.SetPosition(0, pos);
                    LR.SetPosition(1, hit.point);
                    Instantiate(bulletHoleRef).transform.position = hit.point;
                    hit.collider.SendMessage("Damage", BulletDamage);
                }
                else
                {
                    LR.SetPosition(0, pos);
                    LR.SetPosition(1, pos + finalDir * range);
                }
            }
            else
            {

            }
        }

        private void Update()
        {
            lifeTime -= Time.deltaTime;
            if (lifeTime < 0.0f)
                Destroy(gameObject);
        }
    }
}