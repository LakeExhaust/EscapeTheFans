using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject weaponPrefab;
    public GameObject target;
    public float secondsBeforeDestroyed = 3f;
   

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {

        GameObject weapon = Instantiate(weaponPrefab, firePoint.position, firePoint.rotation) as GameObject;
        Destroy(weapon, secondsBeforeDestroyed);

    }
    private void Start()
    {
     
    }
}
