using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CertIVSpeedrun.Player.Week1
{
    public class Week1 : MonoBehaviour
    {
        private Rigidbody myRigidBody;
        [SerializeField] private Button step1Btn;
        
        // Start is called before the first frame update
        private void Start()
        {
            myRigidBody = GetComponent<Rigidbody>();
        }

        public void Step1Button()
        {
            // This will be pressed on the first button.
            myRigidBody.useGravity = true;
            step1Btn.interactable = false;
        }
    }
}