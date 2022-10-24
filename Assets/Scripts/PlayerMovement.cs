using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    private Vector2 movement;
    public Animator animator;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public int localScore = 0;
  
    private void Start()
    {
        currentHealth += maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }
    private void Update()
    {
        HandleInputs();
        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Enemy"))
        {
            takeDamage(2);
        }
    }
    public void takeDamage(int damage)
    {

        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        Moving();
     
    }

    void HandleInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveX, moveY).normalized;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);
     
        }

    void Moving()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);

    }



  

}
    

   


