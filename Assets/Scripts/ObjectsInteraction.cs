using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInteraction : MonoBehaviour {


    public GameObject Menu;
    public GameObject DarkPanel;
    public GameObject Stop;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown ()
    {
        Menu.gameObject.SetActive(true);
        Stop.gameObject.SetActive(true);
        DarkPanel.gameObject.SetActive(true);
        //Time.timeScale = 0.0F;
    }

    public void Off()
    {
        Menu.gameObject.SetActive(false);
       // Time.timeScale = 1.0F;
    }
}
