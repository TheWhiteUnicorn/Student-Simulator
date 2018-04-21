using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AutovProssat : MonoBehaviour {

	Animator animator;
	private NavMeshAgent agent;
	private Vector3 _prevPosition;
	// Use this for initialization

	void Start () {
		animator = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 50000) && Input.GetMouseButton(0)) {
			agent.SetDestination (hit.point);
			animator.SetBool ("Move", true);

			agent.Resume ();
		}

		if(Vector3.Distance(transform.position, agent.destination) < 0.1f){
			agent.Stop ();
			animator.SetBool ("Move", false);
	}


}
}
