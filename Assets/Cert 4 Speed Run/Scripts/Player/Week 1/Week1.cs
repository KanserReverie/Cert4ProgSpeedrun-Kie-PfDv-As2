using BladeRapid;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CertIVSpeedrun.Player.Week1
{
    public class Week1 : MonoBehaviour
    {
        [SerializeField] private Rigidbody myRigidbody;
        [SerializeField] private Button step1Btn;
        [SerializeField] public GameObject UIControls;
        [SerializeField] public GameObject groundChecker;
        [SerializeField] private Animator animatorControler;
        private static readonly int property = Animator.StringToHash("Add Controller");

        // Start is called before the first frame update
        private void Start()
        {
            myRigidbody = GetComponent<Rigidbody>();
            animatorControler = GetComponent<Animator>();
        }

        private void Update()
        {
            if(gameObject.transform.position.x > 0 && myRigidbody.velocity.magnitude <= 0.1f)
            {
                OpenPlayer();
                
            }
        }

        private void OpenPlayer()
        {
            animatorControler.SetTrigger(property);
        }

        public void Step1Button()
        {
            // This will be pressed on the first button.
            myRigidbody.useGravity = true;
            step1Btn.interactable = false;
        }

        public void OpenUIControls()
        {
            UIControls.SetActive(true);
            groundChecker.SetActive(true);
            PlayerControlsManager.Instance.isReady = true;
        }
    }
}