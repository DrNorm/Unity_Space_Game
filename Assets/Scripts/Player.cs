using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float moveSpeed = 10f;
    public float rotationSpeed = 50f;
    private float acceleration = 0 ;
    public float accelerationSpeed = 2 ;
    private Vector3 movement = Vector3.zero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            acceleration+=0.5f*Time.deltaTime * accelerationSpeed;
            if (acceleration > moveSpeed) acceleration = moveSpeed;
        }
        else
        {
            acceleration-=1f * Time.deltaTime * accelerationSpeed;
            if (acceleration < 0) acceleration = 0;
        }

        


            if (Input.GetKey(KeyCode.UpArrow))
        {
            //transform.Translate(Vector3.forward * Time.deltaTime * acceleration);
            movement = Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //transform.Translate(Vector3.back * Time.deltaTime * acceleration);
            movement = -1f * Vector3.forward;

        }

        transform.Translate(movement * Time.deltaTime * acceleration);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-(Vector3.up * Time.deltaTime * rotationSpeed));
            

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);

        }


    }
}
