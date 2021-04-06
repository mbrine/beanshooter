using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;

/*
 *	Responsible for dispatching the OnHover events
 * 
 *  Attach to the player
 */
namespace BeanGame
{
	public class InteractionSystem : MonoBehaviour
	{
        [Header ("References")]
        [SerializeField] protected Tooltip _tooltip;

        [Header ("Customisations")]
        [SerializeField] [Range (0.5f, 5f)] float interactionRange = 2.8f;

		Transform m_camera;

        void Awake()
        {
            if (m_instance != null)
                m_instance = null;

            m_camera = Camera.main.transform;
        }

        void Update()
        {
            bool foundHit = Physics.Raycast( m_camera.position, m_camera.forward, out RaycastHit hitInfo, interactionRange );

            if (!foundHit)
                return;

            GameObject other = hitInfo.collider.gameObject;
            Interactable interactable = other.GetComponent<Interactable>();

            if (interactable != null)
                interactable.OnInteract();
        }

        public void OnHoverEnter( Interactable interactable )
        {
            _tooltip.gameObject.SetActive( true );
            _tooltip.transform.position = transform.position;

            _tooltip.TextBox.text = "[" + interactable.InteractionButton + "]";
            _tooltip.TextBox.text += " " + interactable.InteractionText;
        }

        public void OnHoverExit( Interactable interactable )
        {
            _tooltip.gameObject.SetActive( false );
            _tooltip.TextBox.text = "Interactable.cs : OnHoverExit(), it's debugging time";
        }

#region Singleton Stuffs - No touchy
        private static InteractionSystem m_instance = null;

        public static InteractionSystem Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = FindObjectOfType<InteractionSystem>();

                    if (m_instance == null)
                        m_instance = new GameObject("Instance of " + typeof(InteractionSystem)).AddComponent<InteractionSystem>();
                }

                return m_instance;
            }
        }
#endregion
    }
}
