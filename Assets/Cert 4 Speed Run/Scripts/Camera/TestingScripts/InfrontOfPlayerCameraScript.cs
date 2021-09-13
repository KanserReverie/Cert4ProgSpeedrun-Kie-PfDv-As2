using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CertIVSpeedrun.Camera
{
    public class InfrontOfPlayerCameraScript : MonoBehaviour
    {
        public Transform trackingHelper;

        void Update()
        {
            float newX = trackingHelper.position.x - 2;
            float Z = transform.position.z;
            float newY = trackingHelper.position.y;
            Vector3 targetPosition = new Vector3(newX, newY, Z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.01f * Time.deltaTime);
        }
    }
}