using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CertIVSpeedrun.GeneralScripts
{
    public class FollowScript : MonoBehaviour
    {
        // The transform it follows.
        [SerializeField] private Transform followTransform;
        // The x offset.
        [SerializeField] private float xOffset = 0;
        // They y offset.
        [SerializeField] private float yOffset = 0;

        // Update is called once per frame
        void FixedUpdate()
        {
            this.transform.position = new 
                Vector3(
                    followTransform.position.x + xOffset,
                    followTransform.position.y + yOffset, 
                    this.transform.position.z);
        
        
        }
    }
}