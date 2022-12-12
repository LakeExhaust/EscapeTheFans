using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    public float moveSpeed = 5f;
    public int health=100;
    public Rigidbody2D rb;
    public Camera cam;
   
    Vector2 movement;
    Vector2 mousePos;
    public HealthBar healthBar;
    public Animator anim;
    Health playerHealth;
    // Update is called once per frame
    public bool hasSkinner = false;
    public bool isDead=false;
    private void Start()
    {
        playerHealth = GetComponent<Health>();
        playerHealth.setHealth(health, health);
        healthBar.setMaxHealth(health);
        anim = GetComponent<Animator>();    
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void takeDamage(int damage)
    {
        playerHealth.damage(damage);
        healthBar.setHealth(playerHealth.getHealth());

    }
    private void FixedUpdate()
    {
        if (isDead == false)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }
    
    public void onDeath()
    {
        anim.SetTrigger("isDead");
        isDead = true;


    }
    public void skinnerOn()
    {
        hasSkinner = true;
        anim.SetBool("isEnough", true);
    }

    public void skinnerOff()
    {
        hasSkinner=false;
        anim.SetBool("isEnough", false);
    }

}
