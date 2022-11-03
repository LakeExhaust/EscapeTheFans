using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public float bulletForce=20f;
    GameObject bullet;
    public float cooldown = 0;
     float lastTimeSinceFired;
     public Cooldown UItext;
    public GameObject normalBullet;
    public GameObject secondBullet;
    public GameManger gm;
    bool hasFired = false;
    public GameObject GrenadePrefab;
    GameObject grenade;

    // Update is called once per frame

    private void Start()
    {
       gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManger>();

    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            fire(normalBullet);
          
        }
        fire2();

        if (Input.GetKeyDown(KeyCode.E))
        {
            throwGrenade();
        }
     
    }
    public void fire2()
    {
        if (Input.GetButtonDown("Fire2") && gm.checkWater() == true && gm.hasTimeRunOut() == false)
        {

            hasFired = true;    
            bullet = Instantiate(secondBullet, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);


        }


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
           
            UItext.setCoolDown(cooldown);
            
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
}
 