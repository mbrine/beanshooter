
using UnityEngine;
using System;

namespace BeanGame
{
	[Serializable]
	public class GameCharacter : MonoBehaviour
	{
		[Header("Game Stats")]
		public float      baseHealth;
		public float      currentHealth;

		public GameWeapon currentWeapon;
	}
}