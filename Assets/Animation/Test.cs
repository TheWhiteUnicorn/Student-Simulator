﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	public Animator animController;
	public bool IsOpen = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnMouseDown ()
    { 	
		if (IsOpen == false)
		{
		     animController.SetBool("IdleBool", true);
			IsOpen = true;
		}
		else 
		{
			animController.SetBool("IdleBool", false);
			IsOpen = false;
		}

    }

}
