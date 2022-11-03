using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GrenadeHandler : MonoBehaviour
{
    public bool hasHitEnemy = false;
    public bool hasHitShieldedEnemy = false;
    public Rigidbody2D rb;
    public Animator animator;   
    public GameManger manger;
    public AudioSource src;
    public AudioClip clip;  
    // Start is called before the first frame update
    void Start()
    {
     
        animator = GetComponent<Animator>();    
        manger = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManger>();
        src =gameObject.GetComponent<AudioSource>();
        src.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(stopExplosion());        
            
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
          
            hasHitEnemy = true; 
            rb = enemy.GetComponent<Rigidbody2D>();
            rb.isKinematic = false;
            Vector2 knocback = rb.transform.position - this.transform.position;
            knocback = knocback.normalized * 50;

            rb.AddForce(knocback);  
            Debug.Log(hasHitEnemy);
            playExplosion();    

            if(enemy.hasShield==true)
            {

                hasHitShieldedEnemy=true;       
                Debug.Log("It wokrs on this site");

                enemy.TakeDamage(1);
                manger.changeColor(enemy.gameObject);
               
            }
           
           

        } 
      
    }

    public void playExplosion()
    {
        animator.Play("Explosion");
        explosionSound();
    }

   IEnumerator stopExplosion()
    {
        if (hasHitEnemy == true || hasHitShieldedEnemy==true)   
        {
            yield return new WaitForSeconds((float)0.9);
            Destroy(gameObject);
        }

    }
    public void explosionSound()
    {
        src.Play();
        Debug.Log("Playing explp sound");
    }

}
