using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudyingToggleHandle : MonoBehaviour{
	public Toggle thisToggle;
	
	public void setEnabled(){
		//thisToggle.isOn = true;
		if(thisToggle.isOn)
			thisToggle.interactable = false;
	}

	public void setUncheckAndUnlock(){
		thisToggle.isOn = false;
		thisToggle.interactable = true;
	}
}
