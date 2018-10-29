using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour {

    public float effectDuration;
    protected float effecTimer = 0;
    public Player player;
    public bool isActive = false;


	// Use this for initialization
	protected void Start () {
       
        isActive = false;
        player = GameObject.Find("Player_Ship").GetComponent<Player>(); ;
	}
	
	// Update is called once per frame
	protected void Update () {
        if (isActive)
        {
            
            effect();

        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            
            activate();
        }
    }
    

    public void activate()
    {
        isActive = true;
    }

    public abstract void effect();
}
