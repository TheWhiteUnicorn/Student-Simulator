using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleCharacterControl : MonoBehaviour {

	public Animator animator;
    public Collider coll;
    public Collider coll2;
    public Collider coll3;
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
		if (Physics.Raycast (ray, out hit, 50000) && Input.GetMouseButton(0) && !(coll.Raycast(ray, out hit, 100.0F)) && !(coll2.Raycast(ray, out hit, 100.0F)) && !(coll3.Raycast(ray, out hit, 100.0F))) {
			agent.SetDestination (hit.point);
			animator.SetBool ("Move", true);
			agent.isStopped = false;		
		}

		if(Vector3.Distance(transform.position, agent.destination) < 0.1f){
			agent.isStopped = true;
			animator.SetBool ("Move", false);
		}


	}
}

