using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public float bulletForce=20f;
    GameObject bullet;
    public GameObject normalBullet;
    public float cooldown = 0;
     float lastTimeSinceFired;
     public Cooldown UItext;

    public GameObject secondBullet;
    public GameManger gm;
    bool hasFired = false;
    public GameObject GrenadePrefab;
    GameObject grenade;
    public AudioSource src;
    public AudioClip ac;
    public AudioClip otherClip;
    public bool hasNormalBulletFired = false;
    public GameObject specialBullet;
  
    // Update is called once per frame

    private void Start()
    {
       gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManger>();
       src.clip = ac;

    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            src.Play();
            if (gm.isSkinner() == false)
            {
              
                fire(normalBullet);
            } else if(gm.isSkinner() == true)
            {
              
                fire(specialBullet);    
            }
            hasNormalBulletFired = true;

        }  

        if (Input.GetButtonDown("Fire2") && gm.checkWater() == true && gm.hasTimeRunOut() == false)
        {

           
            fire2();
            src.Play();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            throwGrenade();
        }
     
    }
    public void fire2()
    {
       

            hasFired = true;
            src.clip = otherClip;
            
            bullet = Instantiate(secondBullet, firePoint.position, firePoint.rotation);
           
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            


        


    }

    public void throwGrenade()
    {

        grenade = Instantiate(GrenadePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>();
        
        rb.AddForce(firePoint.up*5, ForceMode2D.Impulse);
    }
    public void fire(GameObject bulletPrefab)
    {
        if (Time.time-lastTimeSinceFired<cooldown)
        {
            gm.setCoolDown(cooldown);
            
            return;
           



        }
        else
        {
           
            lastTimeSinceFired=Time.time;
            if (UItext.IsItCoolDown() == false)
            {
                   
                bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            }
          

        }
        }

       
    

 public void DestroyBullet()
    {
        Destroy(bullet);
    }
  
   public bool isFired()
    {
      return hasFired;
    }

    public bool isNormalBulletFired()
    {
       return hasNormalBulletFired;     
    }
}
 