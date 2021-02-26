using UnityEngine;

namespace BeanGame
{
	[CreateAssetMenu(fileName = "New Look", menuName = "BeanGame/Item Look")]
	public class Looks : ScriptableObject
	{
		public enum LookType
		{
			INVALID,
			CHARACTER_BASE,
			CHARACTER_OUTFIT, // CHARACTER_OUTFIT LOOKS WILL OVERRIDE ALL CHARACTER_NORMAL LOOKS
			CHARACTER_NORMAL, // CHARACTER_NORMAL INCLUDES STUFF LIKE SHIRTS OR SOMETHING
			CHARACTER_OVERLAY, // CHARACTER_OVERLAY IGNORES CHARACTER_OUTFIT

			WEAPON_BASE,
			WEAPON_PART,
			WEAPON_PROJECTILE,
		}

		public LookType      lookType;
		public Mesh          mesh;
		public Material      material;
		public Vector3       offset;
		public Quaternion    rotation;
		public Vector3       scale;
	}

}