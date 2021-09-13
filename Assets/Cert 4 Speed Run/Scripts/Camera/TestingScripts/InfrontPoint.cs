using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CertIVSpeedrun.Camera
{
    public class InfrontPoint : MonoBehaviour
    {
        public float distanceAhead = 5f;
        public GameObject character;
        private Vector3 prevPosition;

        private void Update()
        {
            float newY = 0; 
            if(!CheckCharacterIdle())
            {
                newY = distanceAhead;
            }
            Vector3 targetPosition = new Vector3(0,newY,0);
            targetPosition += transform.position;

            //transform.localPosition = Vector3.Lerp (transform.position, targetPosition, 0.01f * Time.deltaTime);  
            transform.position = Vector3.Lerp (transform.position, targetPosition, 0.01f * Time.deltaTime);  
        }

        private bool CheckCharacterIdle()
        {
            Vector3 curPos = character.transform.position;
            if(prevPosition == curPos)
            {
                prevPosition = curPos;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}