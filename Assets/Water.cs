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
    AudioSource audioSource;    
  public AudioClip clip;
   
    private void Start()
    {
        manger = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManger>();
        audioSource = GetComponent<AudioSource>();  
        audioSource.clip = clip;    
    }
    public void Update()
    {
        if (hasCollided && manger.isPlayerDead()==false)
        {
           
            manger.changeBlue(manger.getPlayer().gameObject);
            
            expire();
           
           
        }
    }

   
    void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
            hasCollided = true;
            audioSource.Play(); 
            
         
             
           
           

           
          
            }
        }

    public void pickUp()
    {
        gameObject.SetActive(true);
        Debug.Log("Shown now");

    }
    public void hideWater()
    {
        gameObject.SetActive(false);
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
           
            manger.playerRevertColor();
            Destroy(gameObject);
        } 
    }
}
