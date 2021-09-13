using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
        // The slow multiplier offset.
        [SerializeField] private float slowMultiplier = 0.4f;
        // The speed to get there.
        [SerializeField] private float speed = 10;
        // The player to follow.
        [SerializeField] private Rigidbody myPlayerRigidbody;

        private Vector3 pointToMoveTo;
        
        // Update is called once per frame
        private void Update()
        {
            // this.transform.position = new Vector3(followTransform.position.x + xOffset, followTransform.position.y + yOffset, this.transform.position.z) + myPlayerRigidbody.velocity*slowMultiplier;
            pointToMoveTo = new Vector3
                (followTransform.position.x + xOffset, 
                    followTransform.position.y + yOffset,
                    this.transform.position.z) + myPlayerRigidbody.velocity*-slowMultiplier;

            transform.localPosition = Vector3.Lerp (transform.position, pointToMoveTo, Time.deltaTime*speed);  
        }

        public void FollowThisPlayer(Transform _PlayerTransform, Rigidbody _PlayerRigidbody)
        {
            followTransform = _PlayerTransform;
            myPlayerRigidbody = _PlayerRigidbody;
        }
    }
}