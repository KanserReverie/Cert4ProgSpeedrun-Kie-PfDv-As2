using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CertIVSpeedrun.Player;

namespace CertIVSpeedrun.UI
{
    public class MainMenuUI : MonoBehaviour
    {
	    public Animator myAnimator;
	    private static readonly int property = Animator.StringToHash("Close Menu Trigger");

	    public void PlayButton()
	    {
		   PlayerManager.Instance.StartGame();
		   myAnimator.SetTrigger(property);
	    }

	    public void ExitButton()
	    {
		    Application.Quit();
	    #if UNITY_EDITOR
		    UnityEditor.EditorApplication.isPlaying = false;
	    #endif
	    }
	}
}