using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRayCast : MonoBehaviour
{
    public Collider coll;
    void Start()
    {
        coll = GetComponent<Collider>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (coll.Raycast(ray, out hit, 100.0F))
                transform.position = ray.GetPoint(100.0F);

        }
    }
}