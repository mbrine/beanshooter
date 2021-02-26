using UnityEngine;
using System;

namespace BeanGame
{
	[CreateAssetMenu(fileName = "New Weapon Part", menuName = "BeanGame/New Weapon Part")]
	public class WeaponPart : ScriptableObject
	{
		public enum PartType
		{
			UNDEFINED,
			SCOPE,
			GRIP,
			MUZZLE,
			MAGAZINE,
		}

		public string     partName;
		public PartType   partType = PartType.UNDEFINED;
		public float      partBonusValue;

		public Looks  partLooks;
	}
}