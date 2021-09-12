using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using CertIVSpeedrun.Player;
using JetBrains.Annotations;
using System;

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
        
        public Text weekNumber;
        public Text toDoList;

        public void LevelUpUI(int _weekNumber, [NotNull] List <string> _toDoList)
        {
            toDoList.text = (""); // <<<--- Resets Quests
            weekNumber.text = ($"Week {_weekNumber}");
            
            for(int i = 0; i < _toDoList.Count; i++)
            {
                toDoList.text += (_toDoList + "");

                if(i + 1 < _toDoList.Count)
                {
                    toDoList.text += ("\n");
                }
            }
        }
    }
}