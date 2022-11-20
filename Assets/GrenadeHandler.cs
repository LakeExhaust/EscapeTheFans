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
    public int knockbackNumber;
    public bool hasHitPlayer = true;
    // Start is called before the first frame update
    void Start()
    {
     
        animator = GetComponent<Animator>();    
        manger = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManger>();
        src = gameObject.GetComponent<AudioSource>();
        src.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
      
        StartCoroutine(stopExplosion());
        
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
          
            hasHitEnemy = true; 
            rb = enemy.GetComponent<Rigidbody2D>();
            rb.isKinematic = false;
            Vector2 knocback = rb.transform.position - this.transform.position;
            knocback = knocback.normalized * 0;

            rb.AddForce(knocback);  
            Debug.Log(hasHitEnemy);
         
            if(enemy.hasShield==true)
            {

                hasHitShieldedEnemy=true;       
                Debug.Log("It wokrs on this site");
                manger.throwGrenadeBack();
               // enemy.TakeDamage(20);
               //manger.changeColor(enemy.gameObject);
                if (manger.getNormalBullet() == true)
                {
                    Debug.Log("Bulletmeister");
                 //   enemy.TakeDamage(50);
                }


            }

          





        } else if(collision.CompareTag("Player"))
        {
            hasHitPlayer = true;
           Player pl = collision.GetComponent<Player>();
            pl.takeDamage(20);
            manger.changeColor(pl.gameObject);
        }


    }

  

   IEnumerator stopExplosion()
    {
     
        if (hasHitEnemy == true)   
        {
            playAnim();
            yield return new WaitForSeconds((float)0.3);
            Destroy(gameObject);

        } 

    }
  public bool hasHit()
    {
        return hasHitEnemy;     
    }

    public void playAnim()
    {
        animator.Play("Explosion");
    }

   public void playBigAnim()
    {
        animator.Play("bigExplo");
    }

}
