using BladeRapid;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CertIVSpeedrun.Player;
using CertIVSpeedrun.Camera;

namespace CertIVSpeedrun.Player.Week3
{
    public class Week3 : MonoBehaviour
    {
        [SerializeField] private Rigidbody myRigidbody;
        [SerializeField] private GameObject[] myArray;
        
        // Start is called before the first frame update
        private void Start()
        {
            
            myRigidbody = GetComponent<Rigidbody>();
            PlayerControlsManager.Instance.speed += 1;
            PlayerControlsManager.Instance.jumpForce += 1;
            FollowAheadScript.Instance.StartLerpingInY();

            foreach(var VARIABLE in myArray)
            {
                VARIABLE.SetActive(true);
            }

                
            for(int i = 0; i < myArray.Length; i++)
            {
                myArray[i].SetActive(false);
            }
        }
    }
}