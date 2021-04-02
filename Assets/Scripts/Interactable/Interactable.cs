using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;

/*
 *  Base class for all interactable scripts to derive from
 */
namespace BeanGame
{
	[RequireComponent (typeof(Collider))]
	public abstract class Interactable : MonoBehaviour
	{
        [Header ("Customisations")]
        [SerializeField] protected string _interactionButton;
        [SerializeField] protected string _interactionText;

        public string InteractionButton => _interactionButton;
        public string InteractionText   => _interactionText;

        public abstract void OnInteract();

        protected void OnMouseEnter() => InteractionSystem.Instance.OnHoverEnter( this );

        protected void OnMouseExit() => InteractionSystem.Instance.OnHoverExit( this );
    }
}
