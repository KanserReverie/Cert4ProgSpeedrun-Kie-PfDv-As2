using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CertIVSpeedrun.Environment
{
    /// <summary>
    /// This will be used just incase I forget to disable something on load.
    /// </summary>
    public class ActivationOnAwake : MonoBehaviour
    {
        public enum TurnOnOrOff
        {
            On,Off
        }
        public TurnOnOrOff turnOnOrOff = TurnOnOrOff.Off;
        
        void Awake()
        {
            if(turnOnOrOff != null)
            {
                if(turnOnOrOff == TurnOnOrOff.Off)
                {
                    this.gameObject.SetActive(false);
                }
                else if(turnOnOrOff == TurnOnOrOff.On)
                {
                    this.gameObject.SetActive(true);
                }
            }
        }
    }
}