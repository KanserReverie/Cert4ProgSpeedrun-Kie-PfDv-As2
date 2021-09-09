using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CertIVSpeedrun.GeneralScripts
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

        // Update is called once per frame
        void Update()
        {
            inFrontPoint = (mainTransform.position - followingTransform.position) * Time.deltaTime * 5;
        }
    }
}