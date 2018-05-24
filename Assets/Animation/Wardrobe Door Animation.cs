using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeDoorAnimation : MonoBehaviour {

	public Animator animController;
	// Use this for initialization
	public bool IsOpen = false;

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
