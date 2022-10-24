using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 10;
  

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
