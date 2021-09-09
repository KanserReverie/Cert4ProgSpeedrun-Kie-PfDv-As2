using UnityEngine;
 
public class Lagging : MonoBehaviour
 
{
	public Transform target;
	public float height = 3.0f;
	public float length = 3.0f;
	public float damping = 5.0f;
	public bool followBehind = true;

	void LateUpdate ()
	{
		Vector3 wantedPosition;

		if(followBehind)
		{
			wantedPosition = target.TransformPoint(-length, height, transform.position.z);
		}
		else
		{
			wantedPosition = target.TransformPoint(-length, height, transform.position.z);
		}
		transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);
	}
}