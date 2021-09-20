using BladeRapid;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CertIVSpeedrun.Player;

namespace CertIVSpeedrun.Player.Week2
{
    public class Week2 : MonoBehaviour
    {
        [SerializeField] private Rigidbody myRigidbody;

        // Start is called before the first frame update
        private void Start()
        {
            myRigidbody = GetComponent<Rigidbody>();
            PlayerControlsManager.Instance.speed += 1;
        }
    }
}