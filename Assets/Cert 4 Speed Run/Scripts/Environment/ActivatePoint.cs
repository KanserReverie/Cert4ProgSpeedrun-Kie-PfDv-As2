using BladeRapid;
using CertIVSpeedrun.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePoint : MonoBehaviour
{
	// Point where can activate the button.
	[SerializeField] private GameObject ActivePoint;

	private bool isInRange = false;
	private bool isClicked = false;

	// Start is called before the first frame update
	void Start() { }

	// Update is called once per frame
	void Update()
	{
		
	}

	private void OnCollisionEnter(Collision other)
	{
		if(other.collider.gameObject.layer == 10)
		{
			isInRange = true;
		}
	}
	private void OnCollisionExit(Collision other)
	{
		if(other.collider.gameObject.layer == 10)
		{
			isInRange = false;
		}
	}
}