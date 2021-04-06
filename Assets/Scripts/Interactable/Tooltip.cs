using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

/*
 *	Attach this script to an empty gameObject, 
 *	with all the tooltip elements as a child of this gameObject
 *
 *  Remember to fill up those references
 */
namespace BeanGame
{
	public class Tooltip : MonoBehaviour
	{
		[SerializeField] Image	  _background;
		[SerializeField] TMP_Text _textBox;

		public TMP_Text TextBox => _textBox;
	}
}
