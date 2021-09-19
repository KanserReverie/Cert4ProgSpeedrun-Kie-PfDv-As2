using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JetBrains.Annotations;

namespace CertIVSpeedrun.UI
{
    public class QuestManager : MonoBehaviour
    {
        
        // Its now a singleton
    #region Singleton Code
        
        private static QuestManager _instance;
        public static QuestManager Instance
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

        [SerializeField] private GameObject questPanel;
        [SerializeField] private GameObject informationCanvas;
        [SerializeField] private Text weekNumber;
        [SerializeField] private Text toDoList;

        public void StartGame()
        {
            questPanel.SetActive(true);
            informationCanvas.SetActive(true);
        }
        
        public void LevelUpUI(int _weekNumber, [NotNull] List <string> _toDoList)
        {
            toDoList.text = (""); // <<<--- Resets Quests
            weekNumber.text = ($"Week {_weekNumber}");
            
            for(int i = 0; i < _toDoList.Count; i++)
            {
                toDoList.text += (_toDoList[i] + "");

                if(i + 1 < _toDoList.Count)
                {
                    toDoList.text += ("\n");
                }
            }
        }
    }
}