using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private float speed;
    [SerializeField]
    private EnemyData enemyData;

    private GameObject player;


    private enemyHealth enemyHealth;

    private Vector3 dist;

    public static int numberOfEnemies;

    public SpriteRenderer spr;
    public float timer = 0.5f;

    public bool enemyHasBeenHit = false;

    public Animator anim;

    public bool hasShield=false;
    private void Awake()

    {
        resetSpeed();
    }
    
        
    
    private void Start()
    {
        anim = GetComponent<Animator>();        
        enemyHealth = GetComponent<enemyHealth>();
        player = GameObject.FindGameObjectWithTag("Player");
        setEnemyValues();
        numberOfEnemies++;
         
       

    }
    private void Update()
    {
        GoTowards();

      
       
    }

  
    private void GoTowards()
    {
        if (player != null)
        {
            dist = player.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        } 
        
    }

    public void stopMovement()
    {
       if(isEnemyDead()==true)
        {
            Debug.Log("Stopping Movement");
        }
    }
    
    public void TakeDamage(int damage)
    {

        
        enemyHealth.takeDamage(damage);
     
    }
    

    public void setEnemyValues()
    {
       enemyHealth.setHealth(enemyData.hp, enemyData.hp);
        damage = enemyData.damage;
        speed = enemyData.speed;
    }

 public int getAmountKilled()
    {
      
        return enemyHealth.amountKileld;
    }

    public void TakeNoDamage(int damage)
    {
        enemyHealth.noDamage(damage);   

    }

    public void increaseSpeed()
    {
        enemyData.speed += 0.5f;


    }

    public void resetSpeed()
    {
        enemyData.speed = 2f;
    }

  public bool isEnemyDead()
    {
        bool value = false;
        if (enemyHealth.getHealth() <= 0)
        {
            return value = true;
        }
       
        return value;
    }


    public void OnDestroy()
    {
        numberOfEnemies--;
    }

    public int getNumberOfEnemies()
    {
        return numberOfEnemies;
    }
    

   public bool getHealth()
    {
        return enemyHealth.IsShieldHealth();
    }

    public void playShield()
    {

        anim.Play("enemyShield");
        hasShield = true;
       
       
    }

    public void stopShied()
    {
        anim.SetBool("hasHit", true);
    }


}

