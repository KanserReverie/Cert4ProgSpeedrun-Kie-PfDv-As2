using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CertIVSpeedrun.Player
{
	[Serializable] 
	public class WeekPlayer : MonoBehaviour
	{
		// The Object the Player will be with collider.
		public GameObject player;
		// List of all the to do list. 
		public List<string> ToDoList = new List<string>();
	}
}