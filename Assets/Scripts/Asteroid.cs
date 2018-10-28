using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {


    private Vector3 axis = Vector3.zero;

	// Use this for initialization
	void Start () {
        axis.x = Random.Range(-90f,90f);
        axis.y = Random.Range(-90f,90f);
        axis.z = Random.Range(-90f,90f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(axis* Time.deltaTime);
	}
}
