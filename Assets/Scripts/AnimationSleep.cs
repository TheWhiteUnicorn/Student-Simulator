using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationSleep : MonoBehaviour {
    public GameObject Sleep;
    private bool check;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoSleep ()
    {
        if (Sleep.activeSelf)
        {
            Sleep.SetActive(false);
        }
        Sleep.SetActive(true);
    }
}
