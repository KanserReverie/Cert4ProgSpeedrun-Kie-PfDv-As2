using BladeRapid;
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
        [SerializeField] private Rigidbody myPlayerRigidbody;

        public void NextLevel()
        {
            // If this isn't the final week, level up.
            if(weekNumber + 1 < player.Count)
            {
                // Changes the Rigidbody and camera over to the new one
                ChangeRigidbodyAndCamera();
                // Next week.
                weekNumber++;
                

                // Updates the quests.
                QuestManager.Instance.LevelUpUI(weekNumber, player[weekNumber].toDoList);
            }
            else
            {
                EndTheGame();
            }
        }

        private void ChangeRigidbodyAndCamera()
        {
                Rigidbody myOldRigidbody = new Rigidbody();
                Vector3 myOldRigidbodyPosition = new Vector3();
                Vector3 myOldRigidbodyVelocity = new Vector3();
                Quaternion myOldRigidbodyRotation = new Quaternion();
                Vector3 myOldRigidbodyAngularVelocity = new Vector3();
                
                if(weekNumber > 0)
                {
                    // Old players Rigidbody.
                    myOldRigidbody = player[weekNumber].player.GetComponentInChildren<Rigidbody>();
                    myOldRigidbodyPosition = myOldRigidbody.position;
                    myOldRigidbodyVelocity = myOldRigidbody.velocity;
                    myOldRigidbodyAngularVelocity = myOldRigidbody.angularVelocity;
                    myOldRigidbodyRotation = myOldRigidbody.rotation;
                }
                
                // Saves the position of the old player.
                Vector3 oldPlayerPosition = player[weekNumber].player.gameObject.transform.position;
                // Moves the player to the old player
                player[weekNumber].player.gameObject.transform.position = oldPlayerPosition;
                // Gets the next Rigidbody.
                myPlayerRigidbody = player[weekNumber + 1].player.GetComponentInChildren<Rigidbody>();
                // Camera will track the new player.
                mainCamera.FollowThisPlayer(player[weekNumber+1].player.transform,myPlayerRigidbody);
                // Turn off the old player.
                player[weekNumber].gameObject.SetActive(false);
                // Turns player on.
                player[weekNumber+1].gameObject.SetActive(true);
                
                // Makes the new Rigidbody the same as the last one.
                if(weekNumber+1 > 1)
                {
                    myPlayerRigidbody.position = myOldRigidbodyPosition;
                    myPlayerRigidbody.velocity = myOldRigidbodyVelocity;
                    myPlayerRigidbody.angularVelocity = myOldRigidbodyAngularVelocity;
                    myPlayerRigidbody.rotation = myOldRigidbodyRotation;
                    PlayerControlsManager.Instance.myRigidbody = myPlayerRigidbody;
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