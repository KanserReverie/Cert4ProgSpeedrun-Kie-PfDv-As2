using UnityEngine;

namespace CertIVSpeedrun.Camera
{
	/// <summary>
	/// Camera Script to lag behind player.
	/// </summary>
	public class Lagging : MonoBehaviour
 
	{
		public float distanceAhead = 5f;
		public GameObject character;
		private Vector3 prevPosition;

		void Update()
		{
			float newZ = 0;
		
			if(!CheckCharacterIdle())
			{
				newZ = distanceAhead;
			}
		
			Vector3 targetPosition = new Vector3(0,0,newZ);

			transform.localPosition = Vector3.Lerp (transform.position, targetPosition, 0.01f * Time.deltaTime);  
		}

		private bool CheckCharacterIdle()
		{
			Vector3 curPos = character.transform.position;
			if(prevPosition == curPos)
			{
				prevPosition = curPos;
				return true;
			}else{
				return false;
			}
		}
	}
}