using UnityEngine;
using CertIVSpeedrun.Player;

namespace CertIVSpeedrun.Environment
{
    public class LevelUpPoint : MonoBehaviour
    {
        [SerializeField] private GameObject[] objectsToDeleteOnLevelup;
        [SerializeField] private GameObject[] objectsToMakeActiveOnLevelup;
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                PlayerManager.Instance.NextLevel();

                if(objectsToDeleteOnLevelup != null)
                {
                    for(int i = 0; i < objectsToDeleteOnLevelup.Length; i++)
                    {
                        GameObject o = objectsToDeleteOnLevelup[i];
                        o.gameObject.SetActive(false);
                    }
                }
                
                if(objectsToMakeActiveOnLevelup != null)
                {
                    for(int i = 0; i < objectsToMakeActiveOnLevelup.Length; i++)
                    {
                        GameObject o = objectsToMakeActiveOnLevelup[i];
                        o.gameObject.SetActive(true);
                    }
                }
            }
            this.gameObject.SetActive(false);
        }
    }
}