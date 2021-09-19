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

		private void Start()
		{
			pointMesh = GetComponent<MeshRenderer>();
			pointMesh.material = activeMaterial;
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
			pointMesh.material = usedMaterial;
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