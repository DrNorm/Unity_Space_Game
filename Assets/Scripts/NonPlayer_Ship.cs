using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayer_Ship : MonoBehaviour {

    public Transform planet1;
    public Transform planet2;

    public float speed = 8f;
    public float minDistance = 2f;
    private float distance;

    private bool isOnPlanet1 = false;
    private bool isOnPlanet2 = true;

    private bool isPlanetLess = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!isPlanetLess)
        {
            if (isOnPlanet1)
            {
                transform.LookAt(planet2.position);
                transform.position = Vector3.MoveTowards(transform.position, planet2.position, Time.deltaTime * speed);
                distance = Vector3.Distance(transform.position, planet2.position);
                if (distance < minDistance)
                {
                    isOnPlanet1 = false;
                    isOnPlanet2 = true;
                }

            }
            else if (isOnPlanet2)
            {
                transform.LookAt(planet1.position);
                transform.position = Vector3.MoveTowards(transform.position, planet1.position, Time.deltaTime * speed);
                distance = Vector3.Distance(transform.position, planet1.position);
                if (distance < minDistance)
                {
                    isOnPlanet1 = true;
                    isOnPlanet2 = false;
                }
            }
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.Rotate(0,100*Time.deltaTime,0);
        }
        
	}


    public void death()
    {
        
    }

    public void signalShipPlanetDestroyed(Transform planet)
    {
        Debug.Log("ship signaled");
        if(planet == planet1 || planet == planet2)
        {
            isPlanetLess = true;
        }
    }
}
