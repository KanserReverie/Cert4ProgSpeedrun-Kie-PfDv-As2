using System;
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
            float distance = 0.3f;
            Vector3 dir = new Vector3(0, -1);

            int layerMask = LayerMask.GetMask($"NormalObjects");
            
            if(!Physics.Raycast(transform.position, dir, out hit, distance,~layerMask))
            {
                PlayerControlsManager.Instance.isGrounded = false;
            }
            else
            {
                PlayerControlsManager.Instance.isGrounded = true;
            }
        }
    }
}