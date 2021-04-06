using UnityEngine;

namespace BeanGame
{
	[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))] 
	public class GameItemComponentWrapper : MonoBehaviour
	{
		public GameItem theItem;

		public void InitItem()
		{
			if (!theItem)
#if UNITY_EDITOR
				DestroyImmediate(gameObject);
#else
				Destroy(gameObject);
#endif

			if (theItem as Weapon != null)
			{
				transform.tag = "GroundItem_Weapon";
			}
			ApplyLooks();

			gameObject.AddComponent<BoxCollider>();
			// TODO: RESIZE BOXCOLLIDER TO MESH'S BOUNDS

			gameObject.AddComponent<Rigidbody>();
		}

		public void ApplyLooks()
		{
			if (!theItem)
			{
				// if there's no item why even bother
				return;
			}

			if (theItem as Weapon != null) // try see if its a weapon
			{
				Weapon w = (Weapon) theItem;
				// if it is, then just go ahead and call its looks method
				//w.InitWeaponLooks();
				if (!w.weaponLooks)
				{
					return;
				}
				GetComponent<MeshFilter>().sharedMesh = w.weaponLooks.mesh;
				GetComponent<MeshRenderer>().material = w.weaponLooks.material;	

			}
		}
	}
}