using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {


    public Transform player;
    public float speed = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 targetPos = player.position;
        targetPos.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);

	}
}
