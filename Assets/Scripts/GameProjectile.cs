using UnityEngine;

namespace BeanGame
{
	[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
	public class GameProjectile : MonoBehaviour
	{
		public Looks                projectileLooks;
		public TrailRenderer        projectileTrail;
		public Vector3              projectileDirection;
		public float                projectileSpeed;

		public GameProjectileEffect projectileEffect;

	}
}