using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CertIVSpeedrun.UI
{
    public class ExitMenuUIFunctions : MonoBehaviour
    {
        public void ExitGame()
        {
            Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        }
    }
}