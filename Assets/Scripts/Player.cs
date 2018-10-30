using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    //movement variables
    public float moveSpeed = 10f;
    public float rotationSpeed = 50f;
    private float acceleration = 0 ;
    public float accelerationSpeed = 2 ;
    private Vector3 movement = Vector3.zero;

    //shoot() variables
    public float shootRange = 3f;
    public int shootLevel = 1;
    public Transform bulletPrefab;
    private float shootTimerMax = 10;
    public float shootTimer = 0;
    

    //scoring
    private int score=0;
    private Text scoreText;

    // Use this for initialization
    void Start () {
        scoreText = GameObject.Find("UIScoreText").GetComponent<Text>();
        scoreText.text = "Score : " + score;
    }
	
	// Update is called once per frame
	void Update () {

        scoreText.text = "Score : "+score;

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

        if (Input.GetKey(KeyCode.Space) )
        {

            if(shootTimer ==0)shoot();
            shootTimer += 50*Time.deltaTime;
            

        }
        if (shootTimer >= shootTimerMax) shootTimer = 0;



    }

    

    //shooting methods
    private void shoot()
    {
        switch (shootLevel)
        {
            case 1:
                shootLvl1();
                break;
            case 2:
                shootLvl2();
                break;
            default :
                shootLvl1();
                break;
        }
    }

    private void shootLvl1()
    {
        Transform bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.gameObject.GetComponent<Bullet>().template = false;
        
    }

    private void shootLvl2()
    {
        Transform bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.gameObject.GetComponent<Bullet>().template = false;


        Vector3 pos2 = transform.position;
        pos2.x -= 1;
        Transform bullet2 = Instantiate(bulletPrefab, pos2, Quaternion.identity);
        bullet2.gameObject.GetComponent<Bullet>().template = false;


        Vector3 pos3 = transform.position;
        pos3.x += 1;
        Transform bullet3 = Instantiate(bulletPrefab, pos3, Quaternion.identity);
        bullet3.gameObject.GetComponent<Bullet>().template = false;
        
    }
    


    //scoring methods
    public void setScore(int s)
    {
        score = s;
    }

    public int getscore()
    {
        return score;
    }

    public void addScore (int s)
    {
        score += s;
    }

}
