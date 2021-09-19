using BladeRapid;
using CertIVSpeedrun.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CertIVSpeedrun.Player;

namespace CertIVSpeedrun.Environment
{
	public class ActivatePoint : MonoBehaviour
	{
		// Has this point been clicked;
		private bool isClicked = false;
		[SerializeField] private Material activeMaterial;
		[SerializeField] private Material usedMaterial;
		[SerializeField] private MeshRenderer PointMesh;

		[SerializeField] private GameObject[] objectsToDeleteOnActivation;


		private void Start()
		{
			PointMesh = GetComponent<MeshRenderer>();
			PointMesh.material = activeMaterial;
			isClicked = false;
		}

		private void OnTriggerEnter(Collider other)
		{
			if(!isClicked)
			{
				if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
				{
					PlayerControlsManager.Instance.ThisPointIsActive(this);
				}
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
			{
				PlayerControlsManager.Instance.LeaveActivePoint();
			}
		}

		public void ActivateThisPoint()
		{
			isClicked = true;
			PointMesh.material = usedMaterial;
			StartCoroutine(nameof(DeleteGameObjects));
		}

		// Deletes all the game objects in the array.
		private IEnumerator DeleteGameObjects()
		{
			if(objectsToDeleteOnActivation != null)
			{
				for(int i = 0; i < objectsToDeleteOnActivation.Length; i++)
				{
					GameObject o = objectsToDeleteOnActivation[i];
					o.gameObject.SetActive(false);
					yield return (1.2f);
				}
			}
		}
	}
}