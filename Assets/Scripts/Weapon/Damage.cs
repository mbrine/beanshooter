using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeanGame
{
	public struct Damage
	{
		public GameCharacter    sourceCharacter; // who shot it
		public float            maxValue;
		public float            minValue;

		public Damage(GameCharacter c, float maxi, float mini)
		{
			sourceCharacter = c;
			maxValue = maxi;
			minValue = mini;
		}

	}
}