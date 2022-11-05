using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFan : MonoBehaviour
{
    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private float speed = 1.5f;
    [SerializeField]
    private EnemyData enemyData;

    private GameObject player;

    private int healthValue;

    private enemyHealth enemyHealth;

    private void Start()
    {
        enemyHealth = GetComponent<enemyHealth>();
        player = GameObject.FindGameObjectWithTag("Player");
        setEnemyValues();


    }
    private void Update()
    {
        GoTowards();



    }

    private void GoTowards()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }


    public void TakeDamage(int damage)
    {


        enemyHealth.bigFanDamage(damage);


    }


    public void setEnemyValues()
    {
        enemyHealth.setHealth(enemyData.hp, enemyData.hp);
        damage = enemyData.damage;
        speed = enemyData.speed;
    }

    public int getAmountKilled()
    {

        return enemyHealth.amountKileld;
    }

    public void TakeNoDamage(int damage)
    {
        enemyHealth.noDamage(damage);

    }

    public bool isBigDead()
    {
        bool value = false;
        if (enemyHealth.getHealth() <= 0)
        {
            value=true;
        }
        else
        {
            value=false;
        }
        return value;
    }

}