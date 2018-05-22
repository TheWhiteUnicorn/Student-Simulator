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

	 /// <summary>
	/// OnMouseDown is called when the user has pressed the mouse button while
	/// over the GUIElement or Collider.
	/// </summary>
	void OnMouseDown()
	{
		Debug.Log("Toggle Clicked");
	}

	public void setUncheckAndUnlock(){
		thisToggle.isOn = false;
		thisToggle.interactable = true;
	}
}
