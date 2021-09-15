using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace CertIVSpeedrun.Player
{
    public class GoundCollider : MonoBehaviour
    {
        public void Update()
        {
            GroundCheck();
        }
        
        void GroundCheck()
        {
            RaycastHit hit;
            float distance = 1f;
            Vector3 dir = new Vector3(0, -1);

            if(Physics.Raycast(transform.position, dir, out hit, distance))
            {
                PlayerControlsManager.Instance.isGrounded = true;
            }
            else
            {
                PlayerControlsManager.Instance.isGrounded = false;
            }
        }
    }
}