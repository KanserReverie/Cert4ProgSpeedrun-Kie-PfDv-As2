using CertIVSpeedrun.Testing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CertIVSpeedrun.Testing
{
    public class ActiveGamobjectsManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Awake()
        {
            TurnOnOrOffOnPlay[] onOffs = FindObjectsOfType<TurnOnOrOffOnPlay>();

            foreach(TurnOnOrOffOnPlay onOff in onOffs)
                onOff.TryActivate();
        }
    }
}