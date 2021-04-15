using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public Transform target;
    //public float distance;

    // Start is called before the first frame update
    void Start()
    {
        //distance = Vector3.Distance(target.position, transform.position);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(target);
    }
}
