using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet :MonoBehaviour
{
    GameManger gm;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManger>();
    }

    public void Update()
    {
        gm.playerRevertColor();
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.takeDamage(20);
            gm.changeColor(player.gameObject);
            
           
        } 
    
       
          
           
        
    }
 

}
