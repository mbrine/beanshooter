using UnityEngine;
using UnityEngine.Rendering;

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
				transform.localPosition               = appliedLook.offset;
				transform.rotation                    = appliedLook.rotation;
				transform.localScale                  = appliedLook.scale;

				foreach (Transform t in transform)
				{
					#if UNITY_EDITOR
						DestroyImmediate(t.gameObject);
					#else
						Destroy(t.gameObject);
					#endif
						
				}
				if (appliedLook.isBillboard)
				{
					GetComponent<MeshFilter>().sharedMesh = null;
					GetComponent<MeshRenderer>().material = null;
					GameObject billboardObj = new GameObject("billboard");
					var meshFil = billboardObj.AddComponent<MeshFilter>();
					var meshRen = billboardObj.AddComponent<MeshRenderer>();
					billboardObj.AddComponent<Billboard>();
					billboardObj.transform.SetParent(transform);
					billboardObj.transform.localPosition = Vector3.zero;
					billboardObj.transform.localScale = Vector3.one;

					meshFil.sharedMesh = Resources.Load<Mesh>("Meshes/planebutrotated");
					meshRen.material = appliedLook.material;
					if (appliedLook.castShadow)
					{
						meshRen.shadowCastingMode = ShadowCastingMode.On;
					}
					else
					{
						meshRen.shadowCastingMode = ShadowCastingMode.Off;
					}
				}
				else
				{
					GetComponent<MeshFilter>().sharedMesh = appliedLook.mesh;
					GetComponent<MeshRenderer>().material = appliedLook.material;
					if (appliedLook.castShadow)
					{
						GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.On;
					}
					else
					{
						GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
					}
				}
			}
			else
			{
				GetComponent<MeshFilter>().sharedMesh = null;
				GetComponent<MeshRenderer>().material = null;
			}
		}
		
	}
}