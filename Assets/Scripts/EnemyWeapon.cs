using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{


    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject weaponPrefab;
    public GameObject target;
    public GameObject enemy;
    float timeLastCall;
   public float startTime;
    public AudioSource src;
    public AudioClip ac;
    private void Start()
    {
        timeLastCall = startTime;
        src = GetComponent<AudioSource>();
        src.clip = ac;
    }

    // Update is called once per frame
    void Update()

    {
        if (target != null)
        {
            float dist = Vector3.Distance(enemy.transform.position, target.transform.position);

            if (dist < 10)
            {
                if (timeLastCall < -0)
                {
                    Shoot();
                    src.Play(); 
                    timeLastCall = startTime;
                }
                else
                {
                    timeLastCall -= Time.deltaTime;
                }

            }
        }
    }
    void Shoot()
    {
       
      GameObject bullet =   Instantiate(weaponPrefab, firePoint.position, firePoint.rotation) as GameObject;
      
        timeLastCall += Time.deltaTime;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    }
}
