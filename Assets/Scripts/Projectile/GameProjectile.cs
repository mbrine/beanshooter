using System;
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

		public void WakeProjectile()
		{
			// TO BE CALLED FROM THE WEAPON ITSELF
			switch (projectileEffect.onFireEffect)
			{
				case GameProjectileEffect.OnFired.HITSCAN:
				{
					// TODO: RAYCAST FROM HERE
					break;
				}
			}
		}

		public void OnTriggerEnter(Collider other)
		{
			
		}
	}
}