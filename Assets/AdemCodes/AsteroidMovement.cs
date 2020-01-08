using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    Rigidbody rigidbody;
    Vector3 vec3;
    public float speed;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        vec3 = new Vector3(0, 1, 0);
    }

    
    void Update()
    {
        rigidbody.velocity = vec3 * -speed;
        
    }
}
