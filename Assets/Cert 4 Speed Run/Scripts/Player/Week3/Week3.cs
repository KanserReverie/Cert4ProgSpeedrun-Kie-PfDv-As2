using BladeRapid;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CertIVSpeedrun.Player;
using CertIVSpeedrun.Camera;
using CertIVSpeedrun.UI;

namespace CertIVSpeedrun.Player.Week3
{
    public class Week3 : MonoBehaviour
    {
        [SerializeField] private Rigidbody myRigidbody;
        
        // Start is called before the first frame update
        private void Start()
        {
            ExitMenu.Instance.ExitGame();
            myRigidbody = GetComponent<Rigidbody>();
            PlayerControlsManager.Instance.speed += 1;
            PlayerControlsManager.Instance.jumpForce += 1;
            FollowAheadScript.Instance.StartLerpingInY();
        }
    }
}