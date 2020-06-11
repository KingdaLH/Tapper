using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkPrefab : MonoBehaviour
{
    public int type; //welk type het wordt
    
    private Rigidbody rb;
    private float speed = 0.5f; //snelheid van prefab
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(transform.right * -speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall1") //Wanneer hij de achterste muur raakt
        {
            Debug.Log("Mis");
            Destroy(gameObject);
            GameManager.health = GameManager.health - 1;
        }     
        if (collision.gameObject.tag == "Customer") //Wanneer hij een customer raakt
        {
            Destroy(gameObject);
            GameManager.score = GameManager.score + 100;
        }   
    }
}


