using UnityEngine;
using System.Collections;

public class TriggerAnimatorControl : MonoBehaviour {
	public string nameTrigger;
	public GameObject gameObjects;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") {
			gameObjects.GetComponent<Animator> ().SetTrigger (nameTrigger);
		}
	}
}
