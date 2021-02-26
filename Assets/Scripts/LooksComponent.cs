using UnityEngine;

namespace BeanGame
{
	[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
	public class LooksComponent : MonoBehaviour
	{
		public Looks appliedLook;

		public Looks AppliedLook
		{
			get => appliedLook;
			set
			{
				appliedLook = value;
				ReApplyLook();
			}
		}

		public void ReApplyLook()
		{
			if (appliedLook != null)
			{
				GetComponent<MeshFilter>().sharedMesh = appliedLook.mesh;
				GetComponent<MeshRenderer>().material = appliedLook.material;
				transform.localPosition               = appliedLook.offset;
				transform.rotation                    = appliedLook.rotation;
				transform.localScale                  = appliedLook.scale;
			}
			else
			{
				GetComponent<MeshFilter>().sharedMesh = null;
				GetComponent<MeshRenderer>().material = null;
			}
		}
		
	}
}