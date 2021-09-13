using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CertIVSpeedrun.Camera
{
    public class FollowAheadScript : MonoBehaviour
    {
        // The transform it follows.
        [SerializeField] private Transform followTransform;
        // The x offset.
        [SerializeField] private float xOffset = 0;
        // The y offset.
        [SerializeField] private float yOffset = 0;
        // The player to follow.
        [SerializeField] private Rigidbody myPlayerRigidbody;

        
        // Update is called once per frame
        private void Update()
        {
            this.transform.position = new Vector3(
                                          followTransform.position.x + xOffset, 
                                          followTransform.position.y + yOffset, 
                                          this.transform.position.z) 
                                      + myPlayerRigidbody.velocity;
        }

        public void FollowThisPlayer(Transform _PlayerTransform, Rigidbody _PlayerRigidbody)
        {
            followTransform = _PlayerTransform;
            myPlayerRigidbody = _PlayerRigidbody;
        }
    }
}