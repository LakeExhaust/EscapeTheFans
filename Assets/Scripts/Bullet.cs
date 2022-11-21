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
  


    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManger>();

     

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
                if (enemy.hasShield == false)
                {
                    Debug.Log("Has fired");
                    manager.changeColor(enemy.gameObject);
                    manager.enemyHit = true;
                    enemy.TakeDamage(damage * 2);
                    manager.playDamage();
                    //     manager.GetShake();
                    Destroy(gameObject);
                } else
                {
                    enemy.TakeNoDamage(damage);
                }
           
            
                
                

            }
            else if (manager.hasFired() == false)
           { 
                if (enemy.hasShield == false)
                {
                  
                    enemy.TakeDamage(damage);
                    manager.changeColor(enemy.gameObject);

                    manager.playDamage();
                    manager.enemyHit = true;
                    Destroy(gameObject);
                    manager.hasReallyHit = true;
                }
                else if(enemy.hasShield == true)
                {
                  
                    enemy.TakeNoDamage(damage);
                 


                }


            }
        }
        //If BigFan gets killed first then spawn the powerup
        else if (collision.CompareTag("BigFan") && manager.isTrue() == false)
        {
            manager.changeColor(bigFan.gameObject);
            manager.enemyHit = true;
          
            bigFan.TakeDamage(damage);
            manager.playDamage();
            //  manager.GetShake();
            if (manager.isBigFan() == true)
            {
                Debug.Log("You get a powerup");
                manager.getWater();
                manager.spawnEnemy(3);
                manager.spawnEnemy(5);
            }
            Destroy(gameObject);
            

            //If first three enemies get killed then we want to spawn a wave with no powerup
        }
        else if (collision.CompareTag("Enemy") && manager.isTrue() == true || collision.CompareTag("BigFan") && manager.isTrue() == true)
        {

            Debug.Log("Spawn more");

            manager.spawnEnemy(5);
            manager.changeColor(bigFan.gameObject);
            manager.enemyHit = true;
           
            bigFan.TakeDamage(damage);
            manager.playDamage();
         //   manager.GetShake();
            Destroy(gameObject);
            
        }

        else if (manager.isBigFan()==true && manager.isEnemy()==true && manager.numberOfEnemies()<=0)
        {
      
                Debug.Log("We're here-Third Codition");
                manager.playerWin();
                Debug.Log("You have won");

            



        }
    }

  

}
     



    
      




   


        
    

