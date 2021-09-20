using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CertIVSpeedrun.UI
{
    public class ExitMenu : MonoBehaviour
    {
        [SerializeField] private GameObject exitMenuUI;
    #region Singleton Code
        private static ExitMenu _instance;
        public static ExitMenu Instance
        {
            get { return _instance; }
        }

        private void Awake()
        {
            if(_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }
    #endregion
        
        public void ExitGame()
        {
            exitMenuUI.gameObject.SetActive(true);
        }
    }
}