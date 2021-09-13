using CertIVSpeedrun.UI;
using CertIVSpeedrun.Camera;
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

        [Tooltip("This is the week number we are on")]
        public static int weekNumber = 0;

        [SerializeField, Tooltip("This the list of all Players")]
        private List<WeekPlayer> player = new List<WeekPlayer>(); // <<<--- ADD IN INSPECTOR ALL LEVELS

        [SerializeField] private FollowAheadScript mainCamera;

        public void NextLevel()
        {
            // If this isn't the final week, level up.
            if(weekNumber + 1 < player.Count)
            {
                // Saves the position of the old player.
                Vector3 oldPlayerPosition = player[weekNumber].player.gameObject.transform.position;
                // Moves the player to the old player
                player[weekNumber].player.gameObject.transform.position = oldPlayerPosition;
                // Camera will track the new player.
                mainCamera.FollowThisPlayer(player[weekNumber+1].player.transform,player[weekNumber+1].player.GetComponent<Rigidbody>());
                // Turn off the old player.
                player[weekNumber].gameObject.SetActive(false);
                // Next week.
                weekNumber++;
                // Turns player on.
                player[weekNumber].gameObject.SetActive(true);
                // Updates the quests.
                QuestManager.Instance.LevelUpUI(weekNumber, player[weekNumber].toDoList);
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

        public void StartGame()
        {
            QuestManager.Instance.StartGame();
            NextLevel();
            mainCamera.enabled = true;
        }
    }
}