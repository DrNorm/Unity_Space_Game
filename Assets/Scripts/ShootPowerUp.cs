﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPowerUp : PowerUp {



	// Use this for initialization
	new void Start () {
        base.Start();

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

        player.shootLevel++;
        isActive = false;
        Destroy(gameObject);

    }
}
