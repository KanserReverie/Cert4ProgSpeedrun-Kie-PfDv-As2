using CertIVSpeedrun.Player;
using System.Collections;
using UnityEngine;

namespace CertIVSpeedrun.Environment
{
	public class ActivatePoint : MonoBehaviour
	{
		// Has this point been clicked;
		private bool isClicked;
		[SerializeField] private Material activeMaterial;
		[SerializeField] private Material usedMaterial;
		[SerializeField] private MeshRenderer pointMesh;
		[SerializeField] private GameObject[] objectsToDeleteOnActivation;
		[SerializeField] private GameObject[] objectsToActivateOnActivation;

		private void Start()
		{
			pointMesh = GetComponent<MeshRenderer>();
			pointMesh.material = activeMaterial;
			isClicked = false;
		}

		private void OnTriggerStay(Collider other)
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
			pointMesh.material = usedMaterial;
			StartCoroutine(nameof(DeleteGameObjects));
			StartCoroutine(nameof(ActivateGameObjects));
		}

		// Deletes all the game objects in the array.
		private IEnumerator DeleteGameObjects()
		{
			if(objectsToDeleteOnActivation != null && objectsToDeleteOnActivation.Length > 0)
			{
				for(int i = 0; i < objectsToDeleteOnActivation.Length; i++)
				{
					GameObject o = objectsToDeleteOnActivation[i];

					if(o != null)
					{
						o.gameObject.SetActive(false);
						yield return (1.2f);
					}
				}
			}
		}
		
		// Activates all the game objects in the array.
		private IEnumerator ActivateGameObjects()
		{
			if(objectsToActivateOnActivation != null && objectsToActivateOnActivation.Length > 0)
			{
				for(int i = 0; i < objectsToActivateOnActivation.Length; i++)
				{
					GameObject o = objectsToActivateOnActivation[i];

					if(o != null)
					{
						o.gameObject.SetActive(true);
						yield return (1.2f);
					}
				}
			}
		}
	}
}