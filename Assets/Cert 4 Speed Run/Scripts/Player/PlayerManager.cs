using CertIVSpeedrun.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;

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

        [Serializable] 
        public class WeekPlayer : MonoBehaviour
        {
            // The Object the Player will be with collider.
            [NotNull] public GameObject player;
            // List of all the to do list. 
            [NotNull] public List<string> ToDoList = new List<string>();
        }
        
        [Tooltip("This is the week number we are on")]
        public static int weekNumber = 0;
        
        [SerializeField, Tooltip("This is the week number we are on")]
        private List<WeekPlayer> player = new List<WeekPlayer>(); // <<<--- ADD IN INSPECTOR ALL LEVELS

        public void NextLevel()
        {
            if(weekNumber + 1 > player.Count)
            {
                player[weekNumber].gameObject.SetActive(false);
                weekNumber++;
                player[weekNumber].gameObject.SetActive(true);
                QuestManager.Instance.LevelUpUI(weekNumber, player[weekNumber].ToDoList);
            }
            else
            {
                EndTheGame();
            }
        }

        private void EndTheGame()
        {
            print("GAME OVER MAN, GAME OVER");
        }
    }
}