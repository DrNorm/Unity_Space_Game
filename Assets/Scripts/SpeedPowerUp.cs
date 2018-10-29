using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUp {

    public float addedSpeed = 10f;
    private bool hasAddedSpeed = false;


    // Use this for initialization
    new void Start () {
        base.Start();
        effectDuration = 10f;
	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();
	}

    new public void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    public override void effect()
    {
        if (effecTimer >= effectDuration)
        {
            player.moveSpeed -= addedSpeed;
            player.accelerationSpeed -= addedSpeed;
            isActive = false;
            Destroy(gameObject);
        }
        if (!hasAddedSpeed)
        {
            player.moveSpeed += addedSpeed;
            player.accelerationSpeed += addedSpeed;

            hasAddedSpeed = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        effecTimer += 1 * Time.deltaTime;
        
    }

}
