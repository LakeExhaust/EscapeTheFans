using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water : MonoBehaviour
{
    public GameObject water;
    public bool hasCollided=false;
    public float timer = 30.0f;
    GameManger manger;
   
    private void Start()
    {
        manger = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManger>();
    }
    public void Update()
    {
        if (hasCollided)
        {
            expire();
           
        }
    }

    public void hideWater()
    {
        gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
            hasCollided = true;
           
         
             
           
           

           
          
            }
        }

    public void pickUp()
    {
        gameObject.SetActive(true);

    }

public bool isWater()
    {
        return hasCollided;
    }

    public void expire()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }
}
