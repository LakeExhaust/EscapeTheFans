using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{

        [SerializeField]
        private int health = 100;
        private int maxHealth = 100;
        public static int amountKileld = 0;
      
       
       public GameManger manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManger>();

    }

        // Update is called once per frame
        void Update()
        {
      
       
          }

    private void FixedUpdate()
    {
       // blockShots();
    }
    public int getHealth()
        {
            return health;
        }
        public void setHealth(int maxHealth, int health)
        {
            this.maxHealth = maxHealth;
            this.health = health;
        }
        public void takeDamage(int damage)
        {
            this.health -= damage;


            if (health <= 0)
            {

            Destroy(gameObject);    
             manager.increaseDead();
              
            }

            }

        
        public void bigFanDamage(int damage)
    {
        this.health -= damage;


        if (health <= 0)
        {
            Debug.Log("Big fan is dead");
            Destroy(gameObject);
            manager.increaseDead();

        }

    }





    public void healUp()
    {
        health = 100;
    }

    public void noDamage(int damage)
    {
     
        {
            health += damage;
            Debug.Log("Enemy health has changed");
            
        } 
    }

    
    }
   

    
