using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{

    public GameObject laser;
    public GameObject explosionEffect;

    GameControlScript gameControl;
    GameObject gameControlObject;


    private void Start()
    {
        gameControlObject = GameObject.FindGameObjectWithTag("GameController");
        gameControl = gameControlObject.GetComponent<GameControlScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.tag.Equals("Border"))
        {
            Destroy(other.gameObject);

            Destroy(gameObject);
           
        }
        
    }

    private void OnDestroy()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        gameControl.increaseScore(10);
    }

}
