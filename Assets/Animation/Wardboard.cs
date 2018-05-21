using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardboard : MonoBehaviour {
	public Animator animController;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*if (Input.GetKeyDown(KeyCode.R))
		{
			animController.SetBool("IdleBool", true);
		}*/
		if (Input.GetKeyDown(KeyCode.T))
		{
			animController.SetBool("IdleBool", false);
		}
		
	}
}
