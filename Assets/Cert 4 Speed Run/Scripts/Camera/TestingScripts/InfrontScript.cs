using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CertIVSpeedrun.Camera
{
    // This will get the first Transform and the trailing one to get a point infront of it.
    public class InfrontScript : MonoBehaviour
    {
        // The transform of the trailing object.
        [SerializeField] private Transform followingTransform;
        // The transform it will go in front of.
        [SerializeField] private Transform mainTransform;
        // The output Vector3 this will take the 2 transforms and give a point in front.
        public Vector3 inFrontPoint;
        
        public float damping = 5.0f;

        // Update is called once per frame
        private void LateUpdate()
        {
            inFrontPoint = (mainTransform.position - followingTransform.position) * Time.deltaTime * 5;
            transform.position = Vector3.Lerp (transform.position, inFrontPoint, Time.deltaTime * damping);
        }
    }
}