
using UnityEngine;
using System;
using System.Collections.Generic;

namespace BeanGame
{
	[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
	public class GameCharacter : MonoBehaviour
	{
		[Header("Game Stats")]
		[SerializeField]
		private float               baseHealth;
		public float                currentHealth;
		[SerializeField]
		private Weapon              currentWeapon; // this is here for the NPCs, since they will have a different weapon
		[Space]
		private bool                isDead = false;
		private bool                willDie = false;
		private bool                isGodMode = false;

		public Looks                looksBase;
		public Looks                looksPart1;
		public Looks                looksPart2;
		public Looks                looksPart3;

		public LooksComponent       looksComponentPart1;
		public LooksComponent       looksComponentPart2;
		public LooksComponent       looksComponentPart3;

		public List<StatusEffect>   statusEffects;

		[Tooltip("Will be true if there are any changes to the entity's stats.")]
		public bool statsIsDirty = false;

		#region events
	
		public delegate void d_characterDeath(GameCharacter c);
		public event d_characterDeath OnCharacterDeath; // will be triggered on entity death.

		public delegate void d_characterTookDamage(GameCharacter c, Damage d);
		public event d_characterTookDamage OnCharacterTakeDamage;

		// will be triggered when the character has an effect applied to them
		public delegate void d_characterEffectAffectedBy(GameCharacter c, StatusEffect se);
		public event d_characterEffectAffectedBy OnCharacterHasEffectAffectedBy; 
		
		#endregion

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

		public void ApplyLooks()
		{
			// https://i.kym-cdn.com/photos/images/original/000/234/739/fa5.jpg
			
			if (looksBase != null)
			{
				if (looksBase.lookType == Looks.LookType.CHARACTER_BASE)
				{
					GetComponent<MeshFilter>().sharedMesh = looksBase.mesh;
					GetComponent<MeshRenderer>().material = looksBase.material;
				}
			}

			if (looksPart1 != null)
			{
				if (looksComponentPart1 == null)
				{
					looksComponentPart1 = new GameObject("lp1").AddComponent<LooksComponent>();
					looksComponentPart1.transform.SetParent(transform);
				}
				looksComponentPart1.appliedLook = looksPart1;
			}
			else
			{
				if (looksComponentPart1 != null)
				{
					Destroy(looksComponentPart1.gameObject);
					looksComponentPart1 = null;
				}
			}

			if (looksPart2 != null)
			{
				if (looksComponentPart2 == null)
				{
					looksComponentPart2 = new GameObject("lp2").AddComponent<LooksComponent>();
					looksComponentPart2.transform.SetParent(transform);
				}
				looksComponentPart2.appliedLook = looksPart2;
			}
			else
			{
				if (looksComponentPart2 != null)
				{
					Destroy(looksComponentPart2.gameObject);
					looksComponentPart2 = null;
				}
			}

			if (looksPart3 != null)
			{
				if (looksComponentPart3 == null)
				{
					looksComponentPart3 = new GameObject("lp3").AddComponent<LooksComponent>();
					looksComponentPart3.transform.SetParent(transform);
				}
				looksComponentPart3.appliedLook = looksPart3;
			}
			else
			{
				if (looksComponentPart3 != null)
				{
					Destroy(looksComponentPart3.gameObject);
					looksComponentPart3 = null;
				}
			}
		}

		public void ApplyEffect(StatusEffect se)
		{
			// TODO:
		}

		public void TakeDamage(Damage d)
		{
			if (isGodMode)
				return; // don't

			OnCharacterTakeDamage?.Invoke(this, d); // triggers all effect when the character takes damage


			float damageValue = UnityEngine.Random.Range(d.minValue, d.maxValue);
			if (currentHealth - damageValue < 0)
			{
				// maybe do health gating to prevent one shots?
				willDie = true;
			}
		}

		public void Update()
		{
			if (willDie)
			{
				// check for anything similar to the totem of undying in minecraft
				OnCharacterDeath?.Invoke(this);
			}

			if (isDead)
			{
				// TODO: CONSIDER STATE MACHINES
			}
			
			
			
			if (statsIsDirty)
			{
				// CheckStats();
				statsIsDirty = false;
			}
		}

		// public void OnCollisionEnter(Collision other)
		// {
		// 	// CHECK BULLET
		// 	// IF BULLET
		// 	//		TakeDamage(other.GetComponent<GameProjectile>().Damage);
		// }
		
		
	}
}