
using UnityEngine;
using System;

namespace BeanGame
{
	public class GameCharacter : MonoBehaviour
	{
		[Header("Game Stats")]
		public float               baseHealth;
		public float               currentHealth;

		public GameWeapon          currentWeapon;

		
		
		public void TakeDamage(GameDamage d)
		{
			
		}
	}
}