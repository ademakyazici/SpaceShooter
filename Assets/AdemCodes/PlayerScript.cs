using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rigidbody;

    float horizontal=0;
    float vertical=0;
    public float hiz;
    Vector3 vec;
    public float egim;

    float minX = -3.35f , maxX=3.35f;
    float minY = -4.3f, maxY = 6.4f;

    float firingTime = 0;
    public float firingInterval;
    public GameObject laser;
    public Transform laserPosition;

    public GameObject explosionEffect;

    GameControlScript gameControl;
    GameObject gameControlObject;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        gameControlObject = GameObject.FindGameObjectWithTag("GameController");
        gameControl = gameControlObject.GetComponent<GameControlScript>();

    }

    private void Update()
    {
        if(Input.GetButton("Fire1") && Time.time>firingTime)
        {
            firingTime = Time.time + firingInterval;
            Instantiate(laser, laserPosition.position, Quaternion.identity);
        }
    }


    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        vec = new Vector3(horizontal,vertical,0);

        rigidbody.velocity = vec*hiz;

        rigidbody.position = new Vector3(
            Mathf.Clamp(rigidbody.position.x, minX, maxX),
            Mathf.Clamp(rigidbody.position.y, minY, maxY),
            -0.4f);

        rigidbody.rotation = Quaternion.Euler(270, 0, rigidbody.velocity.x * -egim);
        


        /*
        if (horizontal != 0)
        {
            transform.Translate(Time.deltaTime * hiz*horizontal, 0, 0);
        }

        if(vertical!= 0)
        {
            transform.Translate(0, Time.deltaTime * hiz*vertical, 0);
        }
        */


    }

    private void OnDestroy()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        gameControl.gameOver();
    }


}
