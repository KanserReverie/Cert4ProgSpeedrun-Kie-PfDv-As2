using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CertIVSpeedrun.Testing
{
    public class TurnOnOrOffOnPlay : MonoBehaviour
    {
        private enum OnOrOffOnPlay { On, Off }

        [Header("Active status of this gameObject on play")] [SerializeField]
        private OnOrOffOnPlay turnOnOrOff = OnOrOffOnPlay.Off;
        public void TryActivate() => this.gameObject.SetActive(turnOnOrOff == OnOrOffOnPlay.On);
    }
}