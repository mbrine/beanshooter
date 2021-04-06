using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

/*
 *	Attach this script to the parent 'Health Bar' gameObject
 */
namespace BeanGame
{
	public class HealthBarController : MonoBehaviour
	{
        [Header("References")]
        [SerializeField] GamePlayerCharacter _player;
        [Space (1)]
		[SerializeField] Image _background;
		[SerializeField] Image _fill;

        void Update()
        {
            _fill.fillAmount = _player.currentHealth / _player.BaseHealth;
        }
    }
}
