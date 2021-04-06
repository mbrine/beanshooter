using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace BeanGame
{
	/*
	 *	- Visualize gun spread using SetCrosshairSpread
	 *	- Change color depending on what Entity you hover over
	 *	
	 *	- Attach this script to the parent 'Crosshair' gameObject
	 */
	[RequireComponent (typeof(RectTransform))]
	public class CrosshairController : MonoBehaviour
	{
#region Variables
        [Header("Customisations")]
		[SerializeField] Color _neutralColor;
		[SerializeField] Color _enemyHoverColor;
		[SerializeField] Color _friendlyHoverColor;

		[Header("References")]
		[SerializeField] List<Image>		 _crosshairUIElements;
		[SerializeField] GamePlayerCharacter _player;

		// Component cache
		RectTransform m_rectTransform;
		Camera		  m_camera;
#endregion

#region Unity Callbacks
        void Awake()
		{
			m_rectTransform = GetComponent<RectTransform>();
			m_camera	    = Camera.main;
		}

        void Start()
        {
			foreach (Image image in _crosshairUIElements)
				image.color = _neutralColor;
		}

		void Update()
        {
			if (_player.CurrentWeapon != null)
				SetCrosshairSize( _player.CurrentWeapon.weaponSpread );
        }
#endregion

#region Public Methods
        public void OnCrosshairOverCharacter( GameCharacter other )
        {
			// TODO :
			// 
			// If enemy, set crosshair UI Elements to 'enemy hover color'
			// Else, set to 'friendly hover color'
        }

		public void OnCrosshairExitCharacter()
        {
			foreach (Image image in _crosshairUIElements)
				image.color = _neutralColor;
        }
#endregion

#region Custom Methods
        void SetCrosshairSize( float weaponSpread )
        {
			/*
			 *	TODO : I can't math
			 *		   Somebody do the calculations for this so it's accurate
			 *		   
			 *		   Use rectTransform.sizeDelta = new Vector2(  );
			 */
		}
#endregion
    }
}
