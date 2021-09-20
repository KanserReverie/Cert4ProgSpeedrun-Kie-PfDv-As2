using UnityEngine;
 
public class ShowCollider : MonoBehaviour {
	void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(transform.position, transform.lossyScale);
	}
}