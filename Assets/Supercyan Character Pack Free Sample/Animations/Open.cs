using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour {
public AnimationClip animationOpen;
	public GameObject OD;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown ()
    {
        OD.gameObject.PlayAnimation(GameObjekt animationOpen.name);
    }
}
