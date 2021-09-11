using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CertIVSpeedrun.Player
{
    /// <summary>
    /// Singleton Player Manager dealing with player stuff.
    /// </summary>
    public class PlayerManager : MonoBehaviour
    {
        // Its now a singleton
    #region Singleton Code
        private static PlayerManager _instance;
        public static PlayerManager Instance
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
    

        public int weekNumber = 0;
        public List<WeekPlayer> player = new List<WeekPlayer>(); // <<<--- ADD IN INSPECTOR ALL LEVELS

        private void Start()
        {
            print("" + player.Count);
        }

        public string NextLevel()
        {
            if (weekNumber + 1> player.Count)
            {}
            return ($"Week{weekNumber}");
        }
    }
}