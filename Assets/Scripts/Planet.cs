using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {


    public float rotationSpeed = 2f;
    public float orbitSpeed = 5f;

    private Transform centre;

	// Use this for initialization
	void Start () {
        centre = GameObject.Find("Sun").transform;
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(Vector3.up*Time.deltaTime*rotationSpeed);

        transform.RotateAround(centre.position, Vector3.up, orbitSpeed*Time.deltaTime);

	}
}
