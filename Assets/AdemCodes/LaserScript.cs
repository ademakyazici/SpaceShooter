using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public GameObject spaceship;
    Rigidbody rigidbody;
    public float velocity;

    public GameObject borders;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        /*Vector3 vecForBullet = new Vector3(0, 0.05f, 0);
        transform.position = spaceship.transform.position+vecForBullet;
        */

        rigidbody.velocity = transform.up * velocity;
    }



}
