using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOnime : MonoBehaviour {

	public GameObject player;
	public Vector3 position;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z);
		transform.position = position;
	}
}
