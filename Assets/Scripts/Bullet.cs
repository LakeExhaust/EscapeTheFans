using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEditor.Scripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 5;
    public int amountKilled = 0;
    GameManger manager;
    public AudioClip clip;
    public AudioSource source;


    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManger>();

        source = GetComponent<AudioSource>();


        source.clip = clip;

    }

    private void Update()
    {
        manager.revertColor();
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        Enemy enemy = collision.GetComponent<Enemy>();
        BigFan bigFan = collision.GetComponent<BigFan>();
       
        // Debug.Log(bigFan == null);


        if (collision.CompareTag("Enemy"))
        {
          
            if (manager.hasFired() == true)
            {
                Debug.Log("Has fired");
                manager.changeColor(enemy.gameObject);
                manager.enemyHit = true;
                enemy.TakeDamage(damage * 2);
                manager.GetShake();
                Destroy(gameObject);
                source.Play();
                
                

            }
            else if (manager.hasFired() == false)
            {
               
                enemy.TakeDamage(damage);
                manager.changeColor(enemy.gameObject);
                source.Play();
                manager.GetShake();
                Debug.Log(source.isPlaying + "Here");
                manager.enemyHit = true;
                Destroy(gameObject);
              
       

            }
        }
        //If BigFan gets killed first then spawn the powerup
        else if (collision.CompareTag("BigFan") && manager.isTrue() == false)
        {
            manager.changeColor(bigFan.gameObject);
            manager.enemyHit = true;
          
            bigFan.TakeDamage(damage);
            manager.GetShake();
            Debug.Log("You get a powerup");
            manager.getWater();
            manager.spawnEnemy(3);
            manager.spawnEnemy(5);
            Destroy(gameObject);
            source.Play();

            //If first three enemies get killed then we want to spawn a wave with no powerup
        }
        else if (collision.CompareTag("Enemy") && manager.isTrue() == true || collision.CompareTag("BigFan") && manager.isTrue() == true)
        {

            Debug.Log("Spawn more");

            manager.spawnEnemy(5);
            manager.changeColor(bigFan.gameObject);
            manager.enemyHit = true;
           
            bigFan.TakeDamage(damage);
            manager.GetShake();
            Destroy(gameObject);
            source.Play();
        }

        else if (manager.isBigFan()==true && manager.isEnemy()==true && manager.numberOfEnemies()<=0)
        {
      
                Debug.Log("We're here-Third Codition");
                manager.playerWin();
                Debug.Log("You have won");

            



        }
    }

  

}
     



    
      




   


        
    

