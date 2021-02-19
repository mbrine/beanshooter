using UnityEngine;
using System;

namespace BeanGame
{
	
	public class WeaponPart : ScriptableObject
	{
		public enum PartType
		{
			SCOPE,
			GRIP,
			MUZZLE,
			MAGAZINE,
		}
	}
}