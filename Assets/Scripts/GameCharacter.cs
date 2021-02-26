
using UnityEngine;
using System;

namespace BeanGame
{
	public class GameCharacter : MonoBehaviour
	{
		[Header("Game Stats")]
		[SerializeField]
		private float               baseHealth;
		public  float               currentHealth;
		[SerializeField]
		private Weapon              currentWeapon; // this is here for the NPCs, since they will have a different weapon
		[Space]
		private bool                isDead = false;
		private bool                isGodMode = false;

		public float BaseHealth
		{
			get => baseHealth;
			set
			{
				baseHealth = value;
				statsIsDirty = true;
			}
		}

		public Weapon CurrentWeapon
		{
			get => currentWeapon;
			set
			{
				currentWeapon = value;
				statsIsDirty = true;
			}
		}

		[Tooltip("Will be true if there are any changes to the entity's stats.\n" +
		         "!!!PLEASE DO NOT MANUALLY CHECK THIS IN THE EDITOR!!!")]
		public bool                statsIsDirty = false;
		
		public void TakeDamage(Damage d)
		{
			if (isGodMode)
				return;
			if (currentHealth - d.value < 0)
			{
				currentHealth = 0f;
				isDead = true;
			}
			else
			{
				currentHealth -= d.value;
			}
		}

		public void Update()
		{
			if (statsIsDirty)
			{
				statsIsDirty = false;
			}
		}

		public void OnCollisionEnter(Collision other)
		{
			// CHECK BULLET
			// IF BULLET
			//		TakeDamage(other.GetComponent<GameProjectile>().Damage);
		}
		
		
	}
}