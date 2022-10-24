using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int health = 100;
    private int maxHealth = 100;
    private static int amountKileld = 0;
    GameManger gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int getHealth() { 
        return health; 
    }   
    public void setHealth(int maxHealth, int health )
    {
        this.maxHealth = maxHealth;
        this.health = health;
    }
    public void damage(int damage)
    {
        this.health -= damage;  
      

       if(health<=0)
        {
            gm.enemyWin();
            Destroy(gameObject);
       
            
        }

    }

   
       
   
}
