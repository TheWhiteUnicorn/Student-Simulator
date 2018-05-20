using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {

	public AudioClip din;
    void OnMouseDown() 
	{
        if(this.name == "din") 
		{
            GetComponent<AudioSource>().PlayOneShot(din);
        }
	}

}
