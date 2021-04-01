using UnityEngine;

namespace BeanGame
{
	[CreateAssetMenu(fileName = "New Projectile Effect", menuName = "BeanGame/Projectile Effect", order = 5)]
	public class GameProjectileEffect : ScriptableObject
	{
		// this class is setup in such a way that there's a start, duration and end
		// in this case, start is when the projectile is just recently fired
		// duration is while the projectile is travelling
		// end is when the projectile hits something, depending on implementation could be on entity hit or w/e

		public enum OnFired
		{
			DEFAULT_FIRE,
			HITSCAN,
			SPLIT,
		}

		// most effective when the projectile is slow moving
        // Should we ignore this when the bullet is hitscan? -matt

		public enum WhileTraveling
		{
			DEFAULT_TRAVEL,
			SPLIT,
			GAIN_WEIGHT, // GOTTA SET PARAMS FOR THIS SOME HOW
			
            ARC_TRAVEL,
		}

		public enum OnHit
		{
			DEFAULT_HIT,
			EXPLODE,
			CHANCE_SET_FIRE,
		}

		public OnFired        onFireEffect;
		public WhileTraveling whileTravelingEffect;
		public OnHit          onHitEffect;

		public float FiredValue;
		public float TravelValue;
		public float HitValue;
	}
}
