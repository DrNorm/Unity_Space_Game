using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Player owner;

    public bool template = false;

    private float lifeLength = 3f;
    private float lifeTime = 0f;

    private Quaternion direction;

	// Use this for initialization
	void Start () {
        if (!template)
        {
            owner = GameObject.Find("Player_Ship").GetComponent<Player>();
            lifeTime = 0;
            direction = owner.transform.rotation;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!template)
        {
            lifeTime += 1 * Time.deltaTime;
            if (lifeTime > lifeLength && template == false)
            {
                Destroy(gameObject);
            }
            if (!template)
            {
                transform.rotation = direction;
                transform.Translate(Vector3.forward * 15 * Time.deltaTime);
            }
        }
        
	}

    void OnCollisionEnter(Collision col)
    {
        if (!template)
        {
            Debug.Log("something hit");

            if (col.gameObject.tag == "Asteroid")
            {
                owner.addScore(5);
                Destroy(col.gameObject);
                Destroy(gameObject);


            }
            if (col.gameObject.tag == "Planet")
            {
                Debug.Log("planet hit");
                col.gameObject.GetComponent<Planet>().death();
                owner.addScore(15);
                Destroy(col.gameObject);
                Destroy(gameObject);


            }
            if (col.gameObject.tag == "Ship")
            {
                col.gameObject.GetComponent<NonPlayer_Ship>().death();
                owner.addScore(5);
                Destroy(col.gameObject);
                Destroy(gameObject);

            }
            if (col.gameObject.tag == "Player")
            {

            }
            else
            {
                if (!template) Destroy(gameObject);
            }
        }
    }

    

}
